using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Infrastructure.Data;
using IYS.Gateway.Infrastructure.HealthChecks;
using IYS.Gateway.Infrastructure.IysApi;
using IYS.Gateway.Infrastructure.Services;
using IYS.Gateway.Infrastructure.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace IYS.Gateway.Infrastructure;

/// <summary>
/// Infrastructure katmanı DI kayıtları.
/// IYS API client (Polly ile), token manager, firm resolver, iş servisleri,
/// consent tracker ve blacklist sync servislerini kaydeder.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string iysBaseUrl, IConfiguration configuration)
    {
        // IYS API Typed HttpClient + Polly resiliency
        services.AddHttpClient<IIysApiClient, IysApiClient>(client =>
        {
            client.BaseAddress = new Uri(iysBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddPolicyHandler(GetRetryPolicy())
        .AddPolicyHandler(GetCircuitBreakerPolicy());

        // Token Manager — distributed cache (MongoDB MONGO_52)
        services.AddSingleton<IIysTokenManager, IysTokenManager>();

        // Firm Resolver — FirmGuid → credentials + brandCode + token
        services.AddScoped<IIysFirmResolver, IysFirmResolver>();

        // Distributed Cache — MongoDB tabanlı, tüm pod'lar paylaşır
        services.AddSingleton<IIysDistributedCache, IysDistributedCache>();

        // İş Servisleri — Controller'lara doğrudan inject edilir
        services.AddScoped<IConsentService, ConsentService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IViaService, ViaService>();

        // ══════════════════════════════════════════════════════════
        // IYS Consent Tracking + Blacklist Sync
        // ══════════════════════════════════════════════════════════

        // Config — SQL kapatılabilirlik toggle
        services.Configure<BlacklistSyncConfig>(
            configuration.GetSection(BlacklistSyncConfig.SectionName));

        // MSSQL DbContext — BusinessRulesLog karaliste/beyazliste
        var sqlConnectionString = configuration.GetConnectionString("Acente365Db")
            ?? configuration["GlobalAdresses:Acente365SqlConnectionString"];
        
        if (!string.IsNullOrEmpty(sqlConnectionString))
        {
            services.AddDbContext<Acente365DbContext>(options =>
                options.UseSqlServer(sqlConnectionString));
        }

        // Servisler
        services.AddScoped<IBlacklistSyncService, BlacklistSyncService>();
        services.AddScoped<IIysConsentTracker, IysConsentTracker>();

        // ══════════════════════════════════════════════════════════

        // [IMPROVEMENT #8] Health Check — MongoDB + IYS API erişilebilirlik
        services.AddHttpClient("IysHealthCheck", client =>
        {
            client.BaseAddress = new Uri(iysBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(5);
        });
        services.AddHealthChecks()
            .AddCheck<MongoHealthCheck>("mongodb", tags: new[] { "db", "mongo" })
            .AddCheck<IysApiHealthCheck>("iys-api", tags: new[] { "external", "iys" });

        // [STARTUP] MongoDB Index'leri — uygulama Ready olmadan önce oluşturulur
        services.AddHostedService<MongoIndexInitializer>();

        return services;
    }

    /// <summary>
    /// Retry policy: 429 ve 5xx hatalarında 3 kez yeniden dener.
    /// Exponential backoff: 2s, 4s, 8s
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    /// <summary>
    /// Circuit breaker: 5 ardışık hata sonrası devre 30 saniye açık kalır.
    /// Ardından half-open duruma geçer ve tek istek test amaçlı gönderilir.
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
    }
}
