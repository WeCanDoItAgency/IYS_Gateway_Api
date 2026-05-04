using System.Collections.Concurrent;
using System.Reflection;
using IYS.Gateway.Application.Common;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Domain.Exceptions;
using IYS.Gateway.Infrastructure.IysApi.Models.Responses;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.IysApi;

/// <summary>
/// IYS Token Yöneticisi. Multi-pod ortamda MongoDB-based distributed token cache ve lock kullanır.
/// Token lifecycle: aktif token varsa kullan → refresh edilebilirse refresh et → yeni al.
/// 
/// Thread-safety (2 katman):
/// Layer 1 — In-process: SemaphoreSlim ile aynı pod içinde stampede önlenir
/// Layer 2 — Cross-pod: MongoDB distributed lock ile podlar arası stampede önlenir
/// 
/// Distributed lock mekanizması:
/// - Pod token almak istediğinde IysTokenLock collection'ına insert dener (FirmGuid unique index)
/// - Başka pod zaten lock almışsa → DuplicateKeyException → bekle + cache'den oku
/// - Lock TTL: 30 saniye (ölü lock'lar otomatik temizlenir)
/// 
/// Konum: MONGO_52 / GlobalAdresses:MongoDbSettings52Database
/// </summary>
public class IysTokenManager : IIysTokenManager
{
    private readonly GenericMongoRepository _repo;
    private readonly IIysApiClient _apiClient;
    private readonly ILogger<IysTokenManager> _logger;
    private readonly string _tokenDb;

    /// <summary>Token süresinden kaç dakika önce yenileme tetiklenir (güvenlik marjı)</summary>
    private const int TokenSafetyMarginMinutes = 5;

    /// <summary>Distributed lock alma denemesi için maksimum bekleme süresi</summary>
    private const int MaxLockWaitSeconds = 15;

    /// <summary>Lock bekleme döngüsünde her deneme arası bekleme süresi (ms)</summary>
    private const int LockPollIntervalMs = 200;

    /// <summary>
    /// In-process lock (Layer 1) — aynı pod içindeki paralel istekleri sıralar.
    /// Bu sayede aynı pod'dan MongoDB'ye tek lock isteği gider.
    /// </summary>
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> _firmLocks = new();

    /// <summary>Pod tanımlayıcı — distributed lock debug logları için</summary>
    private static readonly string _podId = $"{Environment.MachineName}-{Guid.NewGuid():N}".Substring(0, 24);

    public IysTokenManager(
        IIysApiClient apiClient,
        ILogger<IysTokenManager> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
        _repo = new GenericMongoRepository();
        _tokenDb = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database")!;

        // Startup'ta indexleri oluştur (idempotent — varsa atlar)
        _ = EnsureIndexesAsync();
    }

    /// <summary>
    /// IysTokenLock collection'ı üzerinde gerekli indexleri oluşturur.
    /// - FirmGuid unique index: aynı firma için tek lock garantisi
    /// - CreatedAt TTL index: 30 saniye sonra ölü lock'ları otomatik temizler
    /// Idempotent: index zaten varsa sessizce atlar.
    /// </summary>
    private async Task EnsureIndexesAsync()
    {
        try
        {
            var db = GenericMongoConnectionManager.Instance.GetDatabase(OurMongosServer.MONGO_52, _tokenDb);
            var collection = db.GetCollection<IysTokenLockMongo>(
                GetCollectionName<IysTokenLockMongo>());

            var indexModels = new List<CreateIndexModel<IysTokenLockMongo>>
            {
                // Unique index: aynı firma için sadece 1 lock
                new(
                    Builders<IysTokenLockMongo>.IndexKeys.Ascending(x => x.FirmGuid),
                    new CreateIndexOptions { Unique = true, Name = "idx_firmguid_unique" }
                ),
                // TTL index: 30 saniye sonra ölü lock'ları otomatik sil
                new(
                    Builders<IysTokenLockMongo>.IndexKeys.Ascending(x => x.CreatedAt),
                    new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(30), Name = "idx_createdAt_ttl30s" }
                )
            };

            await collection.Indexes.CreateManyAsync(indexModels);
            _logger.LogInformation("IysTokenLock indexleri doğrulandı/oluşturuldu.");
        }
        catch (Exception ex)
        {
            // Index oluşturma başarısız olsa da uygulama çalışmaya devam etmeli
            _logger.LogWarning(ex, "IysTokenLock index oluşturma hatası (uygulama çalışmaya devam ediyor).");
        }
    }

    private static string GetCollectionName<TEntity>()
    {
        var attr = typeof(TEntity).GetCustomAttribute<BsonCollectionAttribute>(false);
        return attr?.CollectionName ?? typeof(TEntity).Name;
    }

    /// <inheritdoc/>
    public async Task<string> GetValidTokenAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        // Fast path: lock almadan cache kontrol
        var cachedToken = await GetCachedTokenAsync(firmGuidStr);
        if (cachedToken != null)
        {
            var now = DateTime.Now;
            if (cachedToken.AccessTokenExpiresAt > now.AddMinutes(TokenSafetyMarginMinutes))
            {
                _logger.LogDebug("FirmGuid {FirmGuid}: Cache'den aktif token kullanılıyor (fast path).", firmGuid);
                return cachedToken.AccessToken;
            }
        }

        // Token dolmuş veya yok → Layer 1 (in-process lock)
        var firmLock = _firmLocks.GetOrAdd(firmGuidStr, _ => new SemaphoreSlim(1, 1));
        await firmLock.WaitAsync();
        try
        {
            // Double-check: aynı pod'da başka thread çözmüş olabilir
            cachedToken = await GetCachedTokenAsync(firmGuidStr);
            if (cachedToken != null &&
                cachedToken.AccessTokenExpiresAt > DateTime.Now.AddMinutes(TokenSafetyMarginMinutes))
            {
                _logger.LogDebug("FirmGuid {FirmGuid}: Aynı pod'da başka istek token almış, cache'den kullanılıyor.", firmGuid);
                return cachedToken.AccessToken;
            }

            // Layer 2: Distributed lock (MongoDB) — podlar arası koordinasyon
            return await AcquireTokenWithDistributedLockAsync(firmGuid, cachedToken);
        }
        finally
        {
            firmLock.Release();
        }
    }

    /// <inheritdoc/>
    public async Task<string> ForceRefreshTokenAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();
        var firmLock = _firmLocks.GetOrAdd(firmGuidStr, _ => new SemaphoreSlim(1, 1));
        await firmLock.WaitAsync();
        try
        {
            _logger.LogInformation("FirmGuid {FirmGuid}: Token zorla yenileniyor (401 retry).", firmGuid);
            return await AcquireTokenWithDistributedLockAsync(firmGuid, cachedToken: null);
        }
        finally
        {
            firmLock.Release();
        }
    }

    /// <summary>
    /// Distributed lock ile token alma/yenileme.
    /// Eğer başka pod zaten lock almışsa → bekle ve cache'den oku.
    /// </summary>
    private async Task<string> AcquireTokenWithDistributedLockAsync(Guid firmGuid, IysTokenCacheMongo? cachedToken)
    {
        var firmGuidStr = firmGuid.ToString();

        if (await TryAcquireDistributedLockAsync(firmGuidStr))
        {
            // Bu pod lock'u aldı → token al/yenile
            try
            {
                if (cachedToken != null &&
                    cachedToken.RefreshTokenExpiresAt > DateTime.Now.AddMinutes(TokenSafetyMarginMinutes))
                {
                    _logger.LogInformation("FirmGuid {FirmGuid}: Token refresh ediliyor.", firmGuid);
                    return await RefreshTokenAsync(firmGuid, cachedToken);
                }

                _logger.LogInformation("FirmGuid {FirmGuid}: Yeni token alınıyor.", firmGuid);
                return await AcquireNewTokenAsync(firmGuid);
            }
            finally
            {
                await ReleaseDistributedLockAsync(firmGuidStr);
            }
        }
        else
        {
            // Başka pod lock'u almış → bekle ve cache'den oku
            _logger.LogInformation("FirmGuid {FirmGuid}: Başka pod token alıyor, bekleniyor...", firmGuid);
            return await WaitForTokenFromCacheAsync(firmGuid);
        }
    }

    /// <summary>
    /// MongoDB'de distributed lock almayı dener.
    /// FirmGuid üzerinde unique index olduğu için, aynı firma için sadece 1 pod lock alabilir.
    /// </summary>
    private async Task<bool> TryAcquireDistributedLockAsync(string firmGuidStr)
    {
        try
        {
            var lockDoc = new IysTokenLockMongo
            {
                FirmGuid = firmGuidStr,
                LockedBy = _podId,
                CreatedAt = DateTime.Now
            };

            await _repo.Query<IysTokenLockMongo>(OurMongosServer.MONGO_52, _tokenDb)
                .InsertOneAsync(lockDoc);

            _logger.LogDebug("Distributed lock alındı: FirmGuid={FirmGuid}, Pod={PodId}", firmGuidStr, _podId);
            return true;
        }
        catch (MongoWriteException ex) when (ex.WriteError?.Category == ServerErrorCategory.DuplicateKey)
        {
            // Başka pod zaten lock almış
            return false;
        }
    }

    /// <summary>
    /// Distributed lock'u serbest bırakır.
    /// </summary>
    private async Task ReleaseDistributedLockAsync(string firmGuidStr)
    {
        try
        {
            await _repo.Query<IysTokenLockMongo>(OurMongosServer.MONGO_52, _tokenDb)
                .Where(x => x.FirmGuid == firmGuidStr)
                .DeleteOneAsync();

            _logger.LogDebug("Distributed lock serbest bırakıldı: FirmGuid={FirmGuid}", firmGuidStr);
        }
        catch (Exception ex)
        {
            // Lock silme başarısız olsa da TTL ile otomatik temizlenecek
            _logger.LogWarning(ex, "Distributed lock silme başarısız: FirmGuid={FirmGuid}", firmGuidStr);
        }
    }

    /// <summary>
    /// Başka pod token alana kadar bekler ve cache'den okur.
    /// Maksimum MaxLockWaitSeconds süre bekler.
    /// </summary>
    private async Task<string> WaitForTokenFromCacheAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();
        var deadline = DateTime.Now.AddSeconds(MaxLockWaitSeconds);

        while (DateTime.Now < deadline)
        {
            await Task.Delay(LockPollIntervalMs);

            var cachedToken = await GetCachedTokenAsync(firmGuidStr);
            if (cachedToken != null &&
                cachedToken.AccessTokenExpiresAt > DateTime.Now.AddMinutes(TokenSafetyMarginMinutes))
            {
                _logger.LogDebug("FirmGuid {FirmGuid}: Başka pod token almış, cache'den kullanılıyor.", firmGuid);
                return cachedToken.AccessToken;
            }
        }

        // Timeout — kendi token'ını almayı dene (lock zaten TTL ile temizlenmiş olabilir)
        _logger.LogWarning("FirmGuid {FirmGuid}: Distributed lock bekleme timeout, kendi token'ını alıyor.", firmGuid);
        return await AcquireNewTokenAsync(firmGuid);
    }

    /// <summary>
    /// Cache'den mevcut token'ı getirir. Thread-safe okuma.
    /// </summary>
    private async Task<IysTokenCacheMongo?> GetCachedTokenAsync(string firmGuidStr)
    {
        return await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, _tokenDb)
            .Where(x => x.FirmGuid == firmGuidStr)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// OAuth2 password grant ile yeni token alır ve MongoDB'ye kaydeder (Upsert).
    /// </summary>
    private async Task<string> AcquireNewTokenAsync(Guid firmGuid)
    {
        var firm = await GetFirmCredentialsAsync(firmGuid);

        var formData = new Dictionary<string, string>
        {
            ["grant_type"] = "password",
            ["username"] = firm.IysUsername!,
            ["password"] = firm.IysPassword!
        };

        var response = await _apiClient.PostFormAsync<Oauth2Response>(IysEndpoints.Token, formData);

        if (response == null)
            throw new IysApiException("IYS token yanıtı boş döndü.", 0);

        var now = DateTime.Now;

        // Upsert: varsa güncelle, yoksa ekle (atomic)
        var update = Builders<IysTokenCacheMongo>.Update
            .Set(x => x.FirmGuid, firmGuid.ToString())
            .Set(x => x.FirmId, firm.MssqlId)
            .Set(x => x.AccessToken, response.AccessToken)
            .Set(x => x.RefreshToken, response.RefreshToken)
            .Set(x => x.AccessTokenExpiresAt, now.AddSeconds(response.ExpiresIn))
            .Set(x => x.RefreshTokenExpiresAt, now.AddSeconds(response.RefreshExpiresIn))
            .Set(x => x.UpdatedAt, now)
            .SetOnInsert(x => x.CreatedAt, now);

        await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, _tokenDb)
            .Where(x => x.FirmGuid == firmGuid.ToString())
            .UpsertOneAsync(update);

        _logger.LogInformation("FirmGuid {FirmGuid}: Yeni token alındı. Expires: {ExpiresAt}",
            firmGuid, now.AddSeconds(response.ExpiresIn));

        return response.AccessToken;
    }

    /// <summary>
    /// Mevcut refresh token ile access token yeniler ve MongoDB'yi günceller.
    /// </summary>
    private async Task<string> RefreshTokenAsync(Guid firmGuid, IysTokenCacheMongo cachedToken)
    {
        try
        {
            var formData = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = cachedToken.RefreshToken
            };

            var response = await _apiClient.PostFormAsync<Oauth2Response>(IysEndpoints.Token, formData);

            if (response == null)
                throw new IysApiException("IYS token refresh yanıtı boş döndü.", 0);

            var now = DateTime.Now;

            var update = Builders<IysTokenCacheMongo>.Update
                .Set(x => x.AccessToken, response.AccessToken)
                .Set(x => x.RefreshToken, response.RefreshToken)
                .Set(x => x.AccessTokenExpiresAt, now.AddSeconds(response.ExpiresIn))
                .Set(x => x.RefreshTokenExpiresAt, now.AddSeconds(response.RefreshExpiresIn))
                .Set(x => x.UpdatedAt, now);

            await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, _tokenDb)
                .Where(x => x.FirmGuid == firmGuid.ToString())
                .UpdateOneAsync(update);

            _logger.LogInformation("FirmGuid {FirmGuid}: Token refresh edildi. Expires: {ExpiresAt}",
                firmGuid, now.AddSeconds(response.ExpiresIn));

            return response.AccessToken;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "FirmGuid {FirmGuid}: Refresh başarısız, yeni token alınıyor.", firmGuid);
            return await AcquireNewTokenAsync(firmGuid);
        }
    }

    /// <summary>
    /// FirmGuid ile MongoDB'den IYS credential'larını okur.
    /// </summary>
    private async Task<NewFirmsMongo> GetFirmCredentialsAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();
        var firm = await _repo.Query<NewFirmsMongo>(OurMongosServer.MONGO_206, "MongoPortal")
            .Where(x =>
                x.FirmGuidStr == firmGuidStr &&
                x.IsActive == true &&
                x.IsIysSystemActive == true)
            .FirstOrDefaultAsync();

        if (firm == null)
            throw new FirmNotFoundException(firmGuid);

        if (string.IsNullOrEmpty(firm.IysUsername) || string.IsNullOrEmpty(firm.IysPassword))
            throw new FirmNotFoundException(firmGuid);

        return firm;
    }
}
