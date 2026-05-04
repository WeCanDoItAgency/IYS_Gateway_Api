using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.IysApi;

/// <summary>
/// MongoDB tabanlı distributed response cache.
/// Multi-pod ortamda tüm pod'lar aynı cache'i okur/yazar.
/// TTL index ile otomatik expire — DBA müdahalesi gerekmez.
/// </summary>
public interface IIysDistributedCache
{
    /// <summary>Cache'den okuma — yoksa null döner</summary>
    Task<T?> GetAsync<T>(string firmGuid, string endpoint, object? parameters = null) where T : class;

    /// <summary>Cache'e yazma — TTL süresi saniye cinsinden</summary>
    Task SetAsync<T>(string firmGuid, string endpoint, T value, int ttlSeconds, object? parameters = null) where T : class;

    /// <summary>Firma bazlı tüm cache'i temizle</summary>
    Task InvalidateAsync(string firmGuid);
}

/// <summary>
/// MongoDB tabanlı distributed response cache implementasyonu.
/// MONGO_52 üzerinde IysResponseCache collection'ına yazar.
/// Index'ler MongoIndexInitializer (IHostedService) tarafından startup'ta oluşturulur.
/// </summary>
public class IysDistributedCache : IIysDistributedCache
{
    private readonly IGenericMongoRepository _mongoRepo;
    private readonly ILogger<IysDistributedCache> _logger;
    private readonly string _database;

    public IysDistributedCache(
        IGenericMongoRepository mongoRepo,
        ILogger<IysDistributedCache> logger)
    {
        _mongoRepo = mongoRepo;
        _logger = logger;
        _database = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database");
    }

    public async Task<T?> GetAsync<T>(string firmGuid, string endpoint, object? parameters = null) where T : class
    {
        var cacheKey = BuildCacheKey(firmGuid, endpoint, parameters);

        var cached = await _mongoRepo.Query<IysResponseCacheMongo>(OurMongosServer.MONGO_52, _database)
            .Where(x => x.CacheKey == cacheKey)
            .FirstOrDefaultAsync();

        if (cached == null)
            return null;

        try
        {
            return JsonSerializer.Deserialize<T>(cached.ResponseJson);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetAsync<T>(string firmGuid, string endpoint, T value, int ttlSeconds, object? parameters = null) where T : class
    {
        var cacheKey = BuildCacheKey(firmGuid, endpoint, parameters);
        var json = JsonSerializer.Serialize(value);

        var doc = new IysResponseCacheMongo
        {
            CacheKey = cacheKey,
            FirmGuid = firmGuid,
            Endpoint = endpoint,
            ResponseJson = json,
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            // Upsert — varsa güncelle, yoksa ekle
            var collection = _mongoRepo.GetCollection<IysResponseCacheMongo>(OurMongosServer.MONGO_52, _database);
            await collection.ReplaceOneAsync(
                Builders<IysResponseCacheMongo>.Filter.Eq(x => x.CacheKey, cacheKey),
                doc,
                new ReplaceOptions { IsUpsert = true });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "IysResponseCache yazma hatası. CacheKey: {CacheKey}", cacheKey);
        }
    }

    public async Task InvalidateAsync(string firmGuid)
    {
        try
        {
            var collection = _mongoRepo.GetCollection<IysResponseCacheMongo>(OurMongosServer.MONGO_52, _database);
            var result = await collection.DeleteManyAsync(
                Builders<IysResponseCacheMongo>.Filter.Eq(x => x.FirmGuid, firmGuid));

            _logger.LogInformation("Firma cache temizlendi. FirmGuid: {FirmGuid}, Silinen: {Count}", firmGuid, result.DeletedCount);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Cache invalidation hatası. FirmGuid: {FirmGuid}", firmGuid);
        }
    }

    /// <summary>
    /// Cache key oluşturma: {FirmGuid}:{Endpoint}:{ParamHash}
    /// </summary>
    private static string BuildCacheKey(string firmGuid, string endpoint, object? parameters)
    {
        if (parameters == null)
            return $"{firmGuid}:{endpoint}";

        var paramJson = JsonSerializer.Serialize(parameters);
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(paramJson)))[..8];
        return $"{firmGuid}:{endpoint}:{hash}";
    }
}
