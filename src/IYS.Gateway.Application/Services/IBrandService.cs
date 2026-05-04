namespace IYS.Gateway.Application.Services;

/// <summary>
/// Marka, bayi, mutabakat ve bilgi servis arayüzü.
/// </summary>
public interface IBrandService
{
    /// <summary>Marka listesi. Rate Limit: 100/dk</summary>
    Task<object?> GetBrandsAsync(Guid firmGuid);

    /// <summary>Marka detayı. Rate Limit: 100/dk</summary>
    Task<object?> GetBrandDetailAsync(Guid firmGuid);

    /// <summary>Bayi listesi. Rate Limit: 100/dk</summary>
    Task<object?> GetRetailersAsync(Guid firmGuid);

    /// <summary>Bayi detayı. Rate Limit: 100/dk</summary>
    Task<object?> GetRetailerDetailAsync(Guid firmGuid, int retailerCode);

    /// <summary>İzin sayısı mutabakat. Rate Limit: 50/dk</summary>
    Task<object?> GetConsentCountAsync(Guid firmGuid, Dictionary<string, string>? queryParams);

    /// <summary>IYS kaynak listesi. Rate Limit: 100/dk</summary>
    Task<object?> GetSourcesAsync(Guid firmGuid);
}
