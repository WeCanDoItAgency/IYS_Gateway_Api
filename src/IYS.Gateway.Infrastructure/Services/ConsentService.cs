using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// İzin yönetimi servis implementasyonu.
/// FirmGuid ile IysFirmResolver → IysApiClient zincirini çalıştırır.
/// </summary>
public class ConsentService : IConsentService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;

    public ConsentService(IIysFirmResolver firmResolver, IIysApiClient apiClient)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
    }

    public async Task<object?> AddSingleConsentAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.AddSingleConsent, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> AddSingleConsentV2Async(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.AddSingleConsentV2, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> AddBatchConsentAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.AddBatchConsent, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> AddBatchConsentV2Async(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.AddBatchConsentV2, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetBatchConsentStatus, ctx.IysCode, ctx.BrandCode, requestId);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetBatchConsentStatusV2, ctx.IysCode, ctx.BrandCode, requestId);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetSingleConsentStatusAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetSingleConsentStatus, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetMultipleConsentStatus, ctx.IysCode, ctx.BrandCode, recipientType, type);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> GetConsentHistoryAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetConsentHistory, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetConsentChanges, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint, queryParams);
    }

    public async Task<object?> RegisterPushAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }

    public async Task<object?> GetPushStatusAsync(Guid firmGuid)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> UnregisterPushAsync(Guid firmGuid, object body)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.PushUnregistration, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
    }
}
