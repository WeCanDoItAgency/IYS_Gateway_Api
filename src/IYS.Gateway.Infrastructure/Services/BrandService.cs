using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Brand;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Infrastructure.IysApi;
using IYS.Gateway.Infrastructure.IysApi.Models.Responses;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// Marka, bayi, mutabakat ve bilgi servis implementasyonu.
/// Tüm API çağrıları ExecuteWithRetryAsync ile sarılır → 401 auto-retry aktif.
/// Sık değişmeyen sorgular (brands, sources) distributed cache ile korunur.
/// </summary>
public class BrandService : IBrandService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;
    private readonly IIysDistributedCache _cache;

    /// <summary>Marka listesi cache süresi — 1 saat (nadiren değişir)</summary>
    private const int BrandsCacheTtlSeconds = 3600;

    /// <summary>IYS kaynakları cache süresi — 24 saat (sabittir)</summary>
    private const int SourcesCacheTtlSeconds = 86400;

    public BrandService(IIysFirmResolver firmResolver, IIysApiClient apiClient, IIysDistributedCache cache)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
        _cache = cache;
    }

    public async Task<List<BrandItem>?> GetBrandsAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        // Cache kontrolü — tüm pod'lar aynı cache'i paylaşır
        var cached = await _cache.GetAsync<List<BrandItem>>(firmGuidStr, "brands");
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<List<BrandItem>>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBrands, ctx.IysCode);
            return await _apiClient.GetAsync<List<BrandItem>>(ctx, endpoint);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "brands", result, BrandsCacheTtlSeconds);

        return result;
    }

    public async Task<BrandDetailResponse?> GetBrandDetailAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        var cached = await _cache.GetAsync<BrandDetailResponse>(firmGuidStr, "brand_detail");
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<BrandDetailResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBrandDetail, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<BrandDetailResponse>(ctx, endpoint);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "brand_detail", result, BrandsCacheTtlSeconds);

        return result;
    }

    public async Task<List<RetailerItem>?> GetRetailersAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        var cached = await _cache.GetAsync<List<RetailerItem>>(firmGuidStr, "retailers");
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<List<RetailerItem>>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetRetailers, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<List<RetailerItem>>(ctx, endpoint);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "retailers", result, BrandsCacheTtlSeconds);

        return result;
    }

    public async Task<RetailerItem?> GetRetailerDetailAsync(Guid firmGuid, int retailerCode)
    {
        return await _firmResolver.ExecuteWithRetryAsync<RetailerItem>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetRetailerDetail, ctx.IysCode, ctx.BrandCode, retailerCode);
            return await _apiClient.GetAsync<RetailerItem>(ctx, endpoint);
        });
    }

    public async Task<ConsentCountResponse?> GetConsentCountAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentCountResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentCount, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<ConsentCountResponse>(ctx, endpoint, queryParams);
        });
    }

    public async Task<List<IysSourceItem>?> GetSourcesAsync(Guid firmGuid)
    {
        var firmGuidStr = firmGuid.ToString();

        // Sources tüm firmalar için aynı — 24 saat cache
        var cached = await _cache.GetAsync<List<IysSourceItem>>(firmGuidStr, "sources");
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<List<IysSourceItem>>(firmGuid, async ctx =>
        {
            return await _apiClient.GetAsync<List<IysSourceItem>>(ctx, IysEndpoints.GetSources);
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "sources", result, SourcesCacheTtlSeconds);

        return result;
    }
}
