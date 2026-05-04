using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.HealthChecks;

/// <summary>
/// MongoDB sunucu bağlantı kontrolü.
/// Her sunucu için ping komutu gönderir ve bağlantı durumunu raporlar.
/// </summary>
public class MongoHealthCheck : IHealthCheck
{
    /// <summary>
    /// Kontrol edilecek Mongo sunucuları ve açıklamaları
    /// </summary>
    private static readonly (OurMongosServer Server, string Name)[] MongoServers =
    [
        (OurMongosServer.MONGO_52, "MONGO_52 (Token/Lock)"),
        (OurMongosServer.MONGO_206, "MONGO_206 (Firmalar)")
    ];

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var data = new Dictionary<string, object>();
        var unhealthy = new List<string>();

        foreach (var (server, name) in MongoServers)
        {
            try
            {
                var connectionString = GenericMongoConnectionManager.Instance.ResolveConnectionString(server);
                var client = GenericMongoConnectionManager.Instance.GetClient(connectionString);
                var db = client.GetDatabase("admin");

                // Ping komutu — bağlantı doğrulama
                var pingResult = await db.RunCommandAsync<BsonDocument>(
                    new BsonDocument("ping", 1), cancellationToken: cancellationToken);

                data[name] = "OK";
            }
            catch (Exception ex)
            {
                data[name] = $"HATA: {ex.Message}";
                unhealthy.Add(name);
            }
        }

        if (unhealthy.Count > 0)
        {
            return HealthCheckResult.Unhealthy(
                $"MongoDB bağlantı hatası: {string.Join(", ", unhealthy)}",
                data: data);
        }

        return HealthCheckResult.Healthy("Tüm MongoDB sunucuları erişilebilir.", data);
    }
}

/// <summary>
/// IYS API erişilebilirlik kontrolü.
/// IYS API base URL'ine basit bir HTTP GET isteği gönderir.
/// </summary>
public class IysApiHealthCheck : IHealthCheck
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IysApiHealthCheck(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("IysHealthCheck");
            var response = await client.GetAsync("/", cancellationToken);

            var data = new Dictionary<string, object>
            {
                ["StatusCode"] = (int)response.StatusCode,
                ["BaseAddress"] = client.BaseAddress?.ToString() ?? "N/A"
            };

            // IYS API genelde 401 döner (token yok) — bu erişilebilir demek
            if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return HealthCheckResult.Healthy("IYS API erişilebilir.", data);
            }

            return HealthCheckResult.Degraded($"IYS API yanıt verdi ama status: {response.StatusCode}", data: data);
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy($"IYS API erişilemez: {ex.Message}");
        }
    }
}
