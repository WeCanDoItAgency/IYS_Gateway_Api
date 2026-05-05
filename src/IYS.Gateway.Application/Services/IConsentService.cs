using IYS.Gateway.Application.Models.Consent;

namespace IYS.Gateway.Application.Services;

/// <summary>
/// İzin yönetimi servis arayüzü.
/// Tekil/toplu izin ekleme, durum sorgulama, geçmiş, değişiklikler ve push bildirim işlemleri.
/// </summary>
public interface IConsentService
{
    /// <summary>Tekil izin ekleme. Rate Limit: 50/dk</summary>
    Task<object?> AddSingleConsentAsync(Guid firmGuid, object body);

    /// <summary>Tekil izin ekleme (v2). Rate Limit: 50/dk</summary>
    Task<object?> AddSingleConsentV2Async(Guid firmGuid, object body);

    /// <summary>Toplu izin ekleme. Max 10.000 kayıt. Rate Limit: 2/dk</summary>
    Task<object?> AddBatchConsentAsync(Guid firmGuid, object body);

    /// <summary>Toplu izin ekleme (v2). Rate Limit: 2/dk</summary>
    Task<object?> AddBatchConsentV2Async(Guid firmGuid, object body);

    /// <summary>Toplu izin sonuç sorgulama. Rate Limit: 20/dk</summary>
    Task<object?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId);

    /// <summary>Toplu izin sonuç sorgulama (v2). Rate Limit: 20/dk</summary>
    Task<object?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId);

    /// <summary>Tekil izin durum sorgulama. Rate Limit: 100/dk</summary>
    Task<object?> GetSingleConsentStatusAsync(Guid firmGuid, object body);

    /// <summary>Çoklu izin durum sorgulama. Max 1.000 alıcı. Rate Limit: 10/dk</summary>
    Task<object?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, object body);

    /// <summary>İzin geçmişi sorgulama. Rate Limit: 100/dk</summary>
    Task<object?> GetConsentHistoryAsync(Guid firmGuid, object body);

    /// <summary>İzin değişiklikleri. Rate Limit: 50/dk</summary>
    Task<object?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams);

    /// <summary>Tekil izin durum senkronizasyonu. Worker'dan çağrılır — MongoDB upsert + karaliste sync.</summary>
    Task SyncConsentStatusAsync(Guid firmGuid, SyncConsentStatusRequest request);

    /// <summary>Push bildirim kaydı. Rate Limit: 5/dk</summary>
    Task<object?> RegisterPushAsync(Guid firmGuid, object body);

    /// <summary>Push bildirim durumu. Rate Limit: 5/dk</summary>
    Task<object?> GetPushStatusAsync(Guid firmGuid);

    /// <summary>Push bildirim silme. Rate Limit: 5/dk</summary>
    Task<object?> UnregisterPushAsync(Guid firmGuid, object body);
}
