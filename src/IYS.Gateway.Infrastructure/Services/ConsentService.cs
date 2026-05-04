using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Infrastructure.IysApi;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// İzin yönetimi servis implementasyonu.
/// FirmGuid ile IysFirmResolver → IysApiClient zincirini çalıştırır.
/// Tüm API çağrıları ExecuteWithRetryAsync ile sarılır → 401 auto-retry aktif.
/// Tekil durum sorgulamaları distributed cache ile korunur (30sn).
/// </summary>
public class ConsentService : IConsentService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;
    private readonly IIysDistributedCache _cache;

    /// <summary>Consent status cache süresi — 30 saniye (sık değişebilir)</summary>
    private const int ConsentStatusCacheTtlSeconds = 30;

    public ConsentService(IIysFirmResolver firmResolver, IIysApiClient apiClient, IIysDistributedCache cache)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
        _cache = cache;
    }

    public async Task<object?> AddSingleConsentAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> AddSingleConsentV2Async(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsentV2, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> AddBatchConsentAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> AddBatchConsentV2Async(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsentV2, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatus, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatusV2, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetSingleConsentStatusAsync(Guid firmGuid, object body)
    {
        var firmGuidStr = firmGuid.ToString();

        // Cache kontrolü — aynı firma + aynı parametreler için 30sn cache
        var cached = await _cache.GetAsync<object>(firmGuidStr, "consent_status", body);
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetSingleConsentStatus, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "consent_status", result, ConsentStatusCacheTtlSeconds, body);

        return result;
    }

    public async Task<object?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetMultipleConsentStatus, ctx.IysCode, ctx.BrandCode, recipientType, type);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetConsentHistoryAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentHistory, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentChanges, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint, queryParams);
        });
    }

    public async Task<object?> RegisterPushAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetPushStatusAsync(Guid firmGuid)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> UnregisterPushAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushUnregistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }
}
