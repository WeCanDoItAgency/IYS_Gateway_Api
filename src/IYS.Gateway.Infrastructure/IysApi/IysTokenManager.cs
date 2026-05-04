using IYS.Gateway.Application.Common;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Domain.Exceptions;
using IYS.Gateway.Infrastructure.IysApi.Models.Responses;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.IysApi;

/// <summary>
/// IYS Token Yöneticisi. Multi-pod ortamda MongoDB-based distributed token cache kullanır.
/// Token lifecycle: aktif token varsa kullan → refresh edilebilirse refresh et → yeni al.
/// Thread-safety: UpdateOneAsync (atomic) ile race condition önlenir.
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

    public IysTokenManager(
        IIysApiClient apiClient,
        ILogger<IysTokenManager> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
        _repo = new GenericMongoRepository();
        _tokenDb = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database")!;
    }

    /// <inheritdoc/>
    public async Task<string> GetValidTokenAsync(Guid firmGuid)
    {
        // 1. Cache'den mevcut token'ı bul
        var firmGuidStr = firmGuid.ToString();
        var cachedToken = await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, _tokenDb)
            .Where(x => x.FirmGuid == firmGuidStr)
            .FirstOrDefaultAsync();

        if (cachedToken != null)
        {
            var now = DateTime.Now;

            // 2. Access token hâlâ geçerli mi?
            if (cachedToken.AccessTokenExpiresAt > now.AddMinutes(TokenSafetyMarginMinutes))
            {
                _logger.LogDebug("FirmGuid {FirmGuid}: Cache'den aktif token kullanılıyor.", firmGuid);
                return cachedToken.AccessToken;
            }

            // 3. Access token dolmuş ama refresh token geçerli mi?
            if (cachedToken.RefreshTokenExpiresAt > now.AddMinutes(TokenSafetyMarginMinutes))
            {
                _logger.LogInformation("FirmGuid {FirmGuid}: Token refresh ediliyor.", firmGuid);
                return await RefreshTokenAsync(firmGuid, cachedToken);
            }

            // 4. Her iki token da dolmuş → yeni token al
            _logger.LogInformation("FirmGuid {FirmGuid}: Tüm tokenlar dolmuş, yeni token alınıyor.", firmGuid);
        }
        else
        {
            _logger.LogInformation("FirmGuid {FirmGuid}: İlk kez token alınıyor.", firmGuid);
        }

        return await AcquireNewTokenAsync(firmGuid);
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

            // Atomic güncelleme
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
