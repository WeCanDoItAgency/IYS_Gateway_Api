using IYS.Gateway.Application.Models.Brand;

namespace IYS.Gateway.Application.Services;

/// <summary>
/// Marka, bayi, mutabakat ve bilgi servis arayüzü.
/// Tüm metotlar typed response modelleri kullanır — object/dynamic YASAKTIR.
/// </summary>
public interface IBrandService
{
    /// <summary>Marka listesi. Rate Limit: 100/dk</summary>
    Task<List<BrandItem>?> GetBrandsAsync(Guid firmGuid);

    /// <summary>Marka detayı. Rate Limit: 100/dk</summary>
    Task<BrandDetailResponse?> GetBrandDetailAsync(Guid firmGuid);

    /// <summary>Bayi listesi. Rate Limit: 100/dk</summary>
    Task<List<RetailerItem>?> GetRetailersAsync(Guid firmGuid);

    /// <summary>Bayi detayı. Rate Limit: 100/dk</summary>
    Task<RetailerItem?> GetRetailerDetailAsync(Guid firmGuid, int retailerCode);

    /// <summary>İzin sayısı mutabakat. Rate Limit: 50/dk</summary>
    Task<ConsentCountResponse?> GetConsentCountAsync(Guid firmGuid, Dictionary<string, string>? queryParams);

    /// <summary>IYS kaynak listesi. Rate Limit: 100/dk</summary>
    Task<List<IysSourceItem>?> GetSourcesAsync(Guid firmGuid);
}
