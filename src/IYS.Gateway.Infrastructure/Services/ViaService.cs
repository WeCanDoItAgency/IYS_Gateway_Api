using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// ViA, KVK, ViaPass, ViaFrame servis implementasyonu.
/// Tüm API çağrıları ExecuteWithRetryAsync ile sarılır → 401 auto-retry aktif.
/// </summary>
public class ViaService : IViaService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;

    public ViaService(IIysFirmResolver firmResolver, IIysApiClient apiClient)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
    }

    public async Task<object?> GetViaSubscriptionsAsync(Guid firmGuid)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetViaSubscriptions, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetViaSubscriptionDetailAsync(Guid firmGuid, string subscriptionCode)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetViaSubscriptionDetail, ctx.IysCode, ctx.BrandCode, subscriptionCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetKvkConsentStatusAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetKvkConsentStatus, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> AddKvkConsentAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddKvkConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> SendViaPassAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaPassSend, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> VerifyViaPassAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaPassVerify, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GenerateViaFrameUrlAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaFrameUrl, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetViaFrameResultAsync(Guid firmGuid, string token)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.ViaFrameResult, ctx.IysCode, ctx.BrandCode, token);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }
}
