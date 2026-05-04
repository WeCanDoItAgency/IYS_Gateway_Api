using IYS.Gateway.Application.Common;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Domain.Exceptions;
using IYS.Gateway.Infrastructure.IysApi.Models.Responses;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.IysApi;

/// <summary>
/// FirmGuid'den IYS credentials, brandCode ve token'ı çözer.
/// Her request'te çağrılır ve tüm auto-resolved parametreleri IysFirmContext olarak döner.
/// brandCode resolve sonucu IysTokenCacheMongo'da cache'lenir (24 saatlik geçerlilik).
/// </summary>
public class IysFirmResolver : IIysFirmResolver
{
    private readonly IIysTokenManager _tokenManager;
    private readonly IIysApiClient _apiClient;
    private readonly GenericMongoRepository _repo;
    private readonly ILogger<IysFirmResolver> _logger;

    /// <summary>brandCode cache geçerlilik süresi (saat)</summary>
    private const int BrandCodeCacheHours = 24;

    public IysFirmResolver(
        IIysTokenManager tokenManager,
        IIysApiClient apiClient,
        ILogger<IysFirmResolver> logger)
    {
        _tokenManager = tokenManager;
        _apiClient = apiClient;
        _logger = logger;
        _repo = new GenericMongoRepository();
    }

    /// <inheritdoc/>
    public async Task<IysFirmContext> ResolveAsync(Guid firmGuid)
    {
        // 1. Firma bilgilerini MongoDB'den oku
        var firmGuidStr = firmGuid.ToString();
        var firm = await _repo.Query<NewFirmsMongo>(OurMongosServer.MONGO_206, "MongoPortal")
            .Where(x =>
                x.FirmGuidStr == firmGuidStr &&
                x.IsActive == true &&
                x.IsIysSystemActive == true)
            .FirstOrDefaultAsync();

        if (firm == null)
            throw new FirmNotFoundException(firmGuid);

        var iysCode = int.Parse(firm.IysCustomerCode!);

        // 2. Token al (cache/refresh/yeni)
        var accessToken = await _tokenManager.GetValidTokenAsync(firmGuid);

        // 3. BrandCode çözümle (cache'den veya API'den)
        var brandCode = await ResolveBrandCodeAsync(firmGuid, iysCode, firm.IysBrand!, accessToken);

        return new IysFirmContext
        {
            FirmGuid = firmGuid,
            FirmId = firm.MssqlId,
            FirmName = firm.FullName ?? "Bilinmeyen",
            IysCode = iysCode,
            BrandCode = brandCode,
            AccessToken = accessToken
        };
    }

    /// <summary>
    /// BrandCode'u cache'den okur veya IYS API'den çözümler.
    /// Cache 24 saat geçerlidir. Marka adı ile eşleşme yapılır.
    /// </summary>
    private async Task<int> ResolveBrandCodeAsync(Guid firmGuid, int iysCode, string brandName, string accessToken)
    {
        var tokenDb = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database")!;

        // Önce cache'e bak
        var firmGuidStr = firmGuid.ToString();
        var cachedToken = await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, tokenDb)
            .Where(x => x.FirmGuid == firmGuidStr)
            .FirstOrDefaultAsync();

        if (cachedToken?.CachedBrandCode.HasValue == true &&
            cachedToken.BrandCodeResolvedAt.HasValue &&
            cachedToken.BrandCodeResolvedAt.Value.AddHours(BrandCodeCacheHours) > DateTime.Now)
        {
            _logger.LogDebug("FirmGuid {FirmGuid}: brandCode cache'den okundu: {BrandCode}",
                firmGuid, cachedToken.CachedBrandCode.Value);
            return cachedToken.CachedBrandCode.Value;
        }

        // Cache miss veya expired → API'den al
        _logger.LogInformation("FirmGuid {FirmGuid}: brandCode API'den çözümleniyor. IysBrand: {BrandName}",
            firmGuid, brandName);

        var tempContext = new IysFirmContext
        {
            FirmGuid = firmGuid,
            AccessToken = accessToken,
            IysCode = iysCode,
            BrandCode = 0,
            FirmId = 0,
            FirmName = ""
        };

        var endpoint = string.Format(IysEndpoints.GetBrands, iysCode);
        var brands = await _apiClient.GetAsync<List<BrandItem>>(tempContext, endpoint);

        var brand = brands?.FirstOrDefault(x =>
            string.Equals(x.Name, brandName, StringComparison.OrdinalIgnoreCase));

        if (brand == null)
            throw new BrandNotFoundException(iysCode, brandName);

        // brandCode'u cache'e yaz (repo Query builder ile)
        var update = Builders<IysTokenCacheMongo>.Update
            .Set(x => x.CachedBrandCode, brand.BrandCode)
            .Set(x => x.BrandCodeResolvedAt, DateTime.Now);

        await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, tokenDb)
            .Where(x => x.FirmGuid == firmGuidStr)
            .UpdateOneAsync(update);

        _logger.LogInformation("FirmGuid {FirmGuid}: brandCode çözümlendi ve cache'lendi: {BrandCode}",
            firmGuid, brand.BrandCode);

        return brand.BrandCode;
    }
}
