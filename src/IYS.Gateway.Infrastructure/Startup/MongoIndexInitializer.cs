using System.Reflection;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Entity.IYS;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Startup;

/// <summary>
/// Uygulama başlatılırken tüm MongoDB index'lerini oluşturur.
/// IHostedService ile çalışır — uygulama READY olmadan önce tamamlanır.
/// Idempotent: index varsa sessizce atlar.
/// 
/// Oluşturulan index'ler:
/// 1. IysTokenLock → FirmGuid unique + CreatedAt TTL (30s)
/// 2. IysResponseCache → CacheKey unique + CreatedAt TTL (300s) + FirmGuid
/// </summary>
public class MongoIndexInitializer : IHostedService
{
    private readonly ILogger<MongoIndexInitializer> _logger;
    private readonly string _database;

    public MongoIndexInitializer(ILogger<MongoIndexInitializer> logger)
    {
        _logger = logger;
        _database = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("MongoDB index başlatma süreci başlıyor...");

        try
        {
            var db = GenericMongoConnectionManager.Instance.GetDatabase(OurMongosServer.MONGO_52, _database);

            // ───── 1. IysTokenLock Index'leri ─────
            await CreateTokenLockIndexes(db, cancellationToken);

            // ───── 2. IysResponseCache Index'leri ─────
            await CreateResponseCacheIndexes(db, cancellationToken);

            // ───── 3. IysRequestConsent Index'leri ─────
            await CreateConsentIndexes(db, cancellationToken);

            // ───── 4. BusinessRulesLog Index'leri (MONGO_206 / MongoPortal) ─────
            var dbPortal = GenericMongoConnectionManager.Instance.GetDatabase(OurMongosServer.MONGO_206, "MongoPortal");
            await CreateBusinessRulesLogIndexes(dbPortal, cancellationToken);

            // ───── 5. IysTokenCache Index'leri ─────
            await CreateTokenCacheIndexes(db, cancellationToken);

            _logger.LogInformation("✅ Tüm MongoDB index'leri başarıyla oluşturuldu/doğrulandı.");
        }
        catch (Exception ex)
        {
            // Index hatası uygulamayı DURDURMASIN — degraded modda çalışsın
            _logger.LogError(ex, "❌ MongoDB index oluşturma hatası! Uygulama çalışmaya devam ediyor.");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>
    /// Token lock collection'ı: distributed lock mekanizması için gerekli index'ler.
    /// </summary>
    private async Task CreateTokenLockIndexes(IMongoDatabase db, CancellationToken ct)
    {
        var collectionName = GetCollectionName<IysTokenLockMongo>();
        var collection = db.GetCollection<IysTokenLockMongo>(collectionName);

        var indexes = new List<CreateIndexModel<IysTokenLockMongo>>
        {
            new(
                Builders<IysTokenLockMongo>.IndexKeys.Ascending(x => x.FirmGuid),
                new CreateIndexOptions { Unique = true, Name = "idx_firmguid_unique" }),
            new(
                Builders<IysTokenLockMongo>.IndexKeys.Ascending(x => x.CreatedAt),
                new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(30), Name = "idx_createdAt_ttl30s" })
        };

        await collection.Indexes.CreateManyAsync(indexes, ct);
        _logger.LogInformation("  ├─ IysTokenLock: 2 index (unique + TTL 30s)");
    }

    /// <summary>
    /// IysTokenCache collection'ı: firma bazlı token lookup için performans index'i.
    /// </summary>
    private async Task CreateTokenCacheIndexes(IMongoDatabase db, CancellationToken ct)
    {
        var collectionName = GetCollectionName<IysTokenCacheMongo>();
        var collection = db.GetCollection<IysTokenCacheMongo>(collectionName);

        var indexes = new List<CreateIndexModel<IysTokenCacheMongo>>
        {
            new(
                Builders<IysTokenCacheMongo>.IndexKeys.Ascending(x => x.FirmGuid),
                new CreateIndexOptions { Name = "idx_firmguid", Background = true })
        };

        await collection.Indexes.CreateManyAsync(indexes, ct);
        _logger.LogInformation("  ├─ IysTokenCache: 1 index (firmguid)");
    }

    /// <summary>
    /// Response cache collection'ı: distributed cache mekanizması için gerekli index'ler.
    /// </summary>
    private async Task CreateResponseCacheIndexes(IMongoDatabase db, CancellationToken ct)
    {
        var collectionName = GetCollectionName<IysResponseCacheMongo>();
        var collection = db.GetCollection<IysResponseCacheMongo>(collectionName);

        var indexes = new List<CreateIndexModel<IysResponseCacheMongo>>
        {
            // Unique index — aynı CacheKey'den sadece 1 kayıt
            new(
                Builders<IysResponseCacheMongo>.IndexKeys.Ascending(x => x.CacheKey),
                new CreateIndexOptions { Unique = true, Name = "idx_cachekey_unique" }),

            // TTL index — 300 saniye sonra otomatik temizlik
            new(
                Builders<IysResponseCacheMongo>.IndexKeys.Ascending(x => x.CreatedAt),
                new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(300), Name = "idx_ttl_createdAt" }),

            // FirmGuid index — firma bazlı invalidation sorgusu
            new(
                Builders<IysResponseCacheMongo>.IndexKeys.Ascending(x => x.FirmGuid),
                new CreateIndexOptions { Name = "idx_firmguid" })
        };

        await collection.Indexes.CreateManyAsync(indexes, ct);
        _logger.LogInformation("  └─ IysResponseCache: 3 index (unique + TTL 300s + firmguid)");
    }

    /// <summary>
    /// IysRequestConsent collection'ı: izin yönetimi sorguları ve güncellemeleri için performans index'leri.
    /// </summary>
    private async Task CreateConsentIndexes(IMongoDatabase db, CancellationToken ct)
    {
        var collectionName = GetCollectionName<IysRequestConsentMongo>();
        var collection = db.GetCollection<IysRequestConsentMongo>(collectionName);

        var indexes = new List<CreateIndexModel<IysRequestConsentMongo>>
        {
            // Compound index — UpdateMany/Upsert filtresi (FirmId + Recipient + Type)
            new(
                Builders<IysRequestConsentMongo>.IndexKeys
                    .Ascending(x => x.FirmId)
                    .Ascending(x => x.Recipient)
                    .Ascending(x => x.Type),
                new CreateIndexOptions { Name = "idx_firmid_recipient_type", Background = true }),

            // Covering index — SubmitConsents pending sorgusu + BulkResolve
            new(
                Builders<IysRequestConsentMongo>.IndexKeys
                    .Ascending(x => x.FirmId)
                    .Ascending(x => x.TransactionId)
                    .Ascending(x => x.Status),
                new CreateIndexOptions { Name = "idx_firmid_txid_status", Background = true })
        };

        await collection.Indexes.CreateManyAsync(indexes, ct);
        _logger.LogInformation("  ├─ IysRequestConsent: 2 index (compound + covering)");
    }

    /// <summary>
    /// BusinessRulesLog collection'ı: karaliste/beyazliste sorguları için performans index'leri.
    /// Server: MONGO_206, Database: MongoPortal
    /// </summary>
    private async Task CreateBusinessRulesLogIndexes(IMongoDatabase db, CancellationToken ct)
    {
        var collectionName = GetCollectionName<BusinessRulesLogMongo>();
        var collection = db.GetCollection<BusinessRulesLogMongo>(collectionName);

        var indexes = new List<CreateIndexModel<BusinessRulesLogMongo>>
        {
            // Compound index — FirmId + IsActive + BusinessRuleId + PhoneNumber (karaliste telefon sorgusu)
            new(
                Builders<BusinessRulesLogMongo>.IndexKeys
                    .Ascending(x => x.FirmId)
                    .Ascending(x => x.IsActive)
                    .Ascending(x => x.BusinessRuleId)
                    .Ascending(x => x.PhoneNumber),
                new CreateIndexOptions { Name = "idx_firmid_active_ruleid_phone", Background = true }),

            // Compound index — FirmId + IsActive + BusinessRuleId + Email (karaliste email sorgusu)
            new(
                Builders<BusinessRulesLogMongo>.IndexKeys
                    .Ascending(x => x.FirmId)
                    .Ascending(x => x.IsActive)
                    .Ascending(x => x.BusinessRuleId)
                    .Ascending(x => x.Email),
                new CreateIndexOptions { Name = "idx_firmid_active_ruleid_email", Background = true })
        };

        await collection.Indexes.CreateManyAsync(indexes, ct);
        _logger.LogInformation("  └─ BusinessRulesLog: 2 index (phone + email karaliste)");
    }

    private static string GetCollectionName<T>()
    {
        var attr = typeof(T).GetCustomAttribute<BsonCollectionAttribute>(false);
        return attr?.CollectionName ?? typeof(T).Name;
    }
}
