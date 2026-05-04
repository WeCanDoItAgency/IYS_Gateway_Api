using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// Marka, bayi, mutabakat ve bilgi servis implementasyonu.
/// </summary>
public class BrandService : IBrandService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;

    public BrandService(IIysFirmResolver firmResolver, IIysApiClient apiClient)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
    }

    public async Task<object?> GetBrandsAsync(Guid firmGuid)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetBrands, ctx.IysCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetBrandDetailAsync(Guid firmGuid)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetBrandDetail, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetRetailersAsync(Guid firmGuid)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetRetailers, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetRetailerDetailAsync(Guid firmGuid, int retailerCode)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetRetailerDetail, ctx.IysCode, ctx.BrandCode, retailerCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint);
    }

    public async Task<object?> GetConsentCountAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        var endpoint = string.Format(IysEndpoints.GetConsentCount, ctx.IysCode, ctx.BrandCode);
        return await _apiClient.GetAsync<object>(ctx, endpoint, queryParams);
    }

    public async Task<object?> GetSourcesAsync(Guid firmGuid)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);
        return await _apiClient.GetAsync<object>(ctx, IysEndpoints.GetSources);
    }
}
