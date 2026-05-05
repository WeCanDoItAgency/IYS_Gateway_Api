using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Application.Models.Common;

namespace IYS.Gateway.Application.Services;

/// <summary>
/// İzin yönetimi servis arayüzü.
/// Tekil/toplu izin ekleme, durum sorgulama, geçmiş, değişiklikler ve push bildirim işlemleri.
/// Tüm metotlar typed request/response modelleri kullanır — object ve dynamic YASAKTIR.
/// </summary>
public interface IConsentService
{
    /// <summary>Tekil izin ekleme. Rate Limit: 50/dk</summary>
    Task<ConsentResponse?> AddSingleConsentAsync(Guid firmGuid, AddSingleConsentRequest request);

    /// <summary>Tekil izin ekleme (v2). Rate Limit: 50/dk</summary>
    Task<ConsentResponse?> AddSingleConsentV2Async(Guid firmGuid, AddSingleConsentRequest request);

    /// <summary>Toplu izin ekleme. Max 10.000 kayıt. Rate Limit: 2/dk</summary>
    Task<BatchConsentResponse?> AddBatchConsentAsync(Guid firmGuid, AddBatchConsentRequest request);

    /// <summary>Toplu izin ekleme (v2). Rate Limit: 2/dk</summary>
    Task<BatchConsentResponse?> AddBatchConsentV2Async(Guid firmGuid, AddBatchConsentRequest request);

    /// <summary>Toplu izin sonuç sorgulama. Rate Limit: 20/dk</summary>
    Task<List<BatchConsentStatusItem>?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId);

    /// <summary>Toplu izin sonuç sorgulama (v2). Rate Limit: 20/dk</summary>
    Task<List<BatchConsentStatusItem>?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId);

    /// <summary>Tekil izin durum sorgulama. Rate Limit: 100/dk</summary>
    Task<ConsentStatusResponse?> GetSingleConsentStatusAsync(Guid firmGuid, GetConsentStatusRequest request);

    /// <summary>Çoklu izin durum sorgulama. Max 1.000 alıcı. Rate Limit: 10/dk</summary>
    Task<MultipleConsentStatusResponse?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, GetMultipleConsentStatusRequest request);

    /// <summary>İzin geçmişi sorgulama. Rate Limit: 100/dk</summary>
    Task<ConsentHistoryResponse?> GetConsentHistoryAsync(Guid firmGuid, GetConsentHistoryRequest request);

    /// <summary>İzin değişiklikleri. Rate Limit: 50/dk</summary>
    Task<ConsentChangesResponse?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams);

    /// <summary>Günlük değişiklik dosyası. Rate Limit: 5/dk</summary>
    Task<ConsentChangesResponse?> GetDailyChangeFileAsync(Guid firmGuid, string reportDate);

    /// <summary>Tekil izin durum senkronizasyonu. Worker'dan çağrılır — MongoDB upsert + karaliste sync.</summary>
    Task SyncConsentStatusAsync(Guid firmGuid, SyncConsentStatusRequest request);

    /// <summary>Push bildirim kaydı. Rate Limit: 5/dk</summary>
    Task<IysErrorResponse?> RegisterPushAsync(Guid firmGuid, RegisterPushRequest request);

    /// <summary>Push bildirim durumu. Rate Limit: 5/dk</summary>
    Task<IysErrorResponse?> GetPushStatusAsync(Guid firmGuid);

    /// <summary>Push bildirim silme. Rate Limit: 5/dk</summary>
    Task<IysErrorResponse?> UnregisterPushAsync(Guid firmGuid, UnregisterPushRequest request);
}
