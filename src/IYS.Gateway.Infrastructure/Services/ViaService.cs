using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Via;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Infrastructure.IysApi;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// ViA, KVK, ViaPass, ViaFrame servis implementasyonu.
/// Tüm API çağrıları ExecuteWithRetryAsync ile sarılır → 401 auto-retry aktif.
/// ViA abonelik sorgulamaları distributed cache ile korunur.
/// </summary>
public class ViaService : IViaService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;
    private readonly IIysDistributedCache _cache;

    /// <summary>ViA abonelik listesi cache süresi — 1 saat</summary>
    private const int SubscriptionsCacheTtlSeconds = 3600;

    public ViaService(IIysFirmResolver firmResolver, IIysApiClient apiClient, IIysDistributedCache cache)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
        _cache = cache;
    }

    public async Task<List<ViaSubscriptionItem>?> GetViaSubscriptionsAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        var cached = await _cache.GetAsync<List<ViaSubscriptionItem>>(firmGuidStr, "via_subscriptions");
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<List<ViaSubscriptionItem>>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetViaSubscriptions, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<List<ViaSubscriptionItem>>(ctx, endpoint);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "via_subscriptions", result, SubscriptionsCacheTtlSeconds);

        return result;
    }

    public async Task<ViaSubscriptionItem?> GetViaSubscriptionDetailAsync(Guid firmGuid, string subscriptionCode)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ViaSubscriptionItem>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetViaSubscriptionDetail, ctx.IysCode, ctx.BrandCode, subscriptionCode);
            return await _apiClient.GetAsync<ViaSubscriptionItem>(ctx, endpoint);
        });
    }

    public async Task<KvkConsentStatusResponse?> GetKvkConsentStatusAsync(Guid firmGuid, GetKvkConsentStatusRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<KvkConsentStatusResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetKvkConsentStatus, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<GetKvkConsentStatusRequest, KvkConsentStatusResponse>(ctx, endpoint, request);
        });
    }

    public async Task<KvkConsentResponse?> AddKvkConsentAsync(Guid firmGuid, AddKvkConsentRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<KvkConsentResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddKvkConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<AddKvkConsentRequest, KvkConsentResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ViaPassSendResponse?> SendViaPassAsync(Guid firmGuid, SendViaPassRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ViaPassSendResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaPassSend, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<SendViaPassRequest, ViaPassSendResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ViaPassVerifyResponse?> VerifyViaPassAsync(Guid firmGuid, VerifyViaPassRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ViaPassVerifyResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaPassVerify, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<VerifyViaPassRequest, ViaPassVerifyResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ViaFrameUrlResponse?> GenerateViaFrameUrlAsync(Guid firmGuid, GenerateViaFrameUrlRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ViaFrameUrlResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaFrameUrl, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<GenerateViaFrameUrlRequest, ViaFrameUrlResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ViaFrameResultResponse?> GetViaFrameResultAsync(Guid firmGuid, string token)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ViaFrameResultResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaFrameResult, ctx.IysCode, ctx.BrandCode, token);
            return await _apiClient.GetAsync<ViaFrameResultResponse>(ctx, endpoint);
        });
    }
}
