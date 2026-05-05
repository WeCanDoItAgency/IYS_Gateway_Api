using IYS.Gateway.Application.Models.Via;

namespace IYS.Gateway.Application.Services;

/// <summary>
/// ViA, KVK, ViaPass, ViaFrame servis arayüzü.
/// Tüm metotlar typed request/response modelleri kullanır — object/dynamic YASAKTIR.
/// </summary>
public interface IViaService
{
    /// <summary>ViA abonelik listesi. Rate Limit: 50/dk</summary>
    Task<List<ViaSubscriptionItem>?> GetViaSubscriptionsAsync(Guid firmGuid);

    /// <summary>ViA abonelik detayı. Rate Limit: 50/dk</summary>
    Task<ViaSubscriptionItem?> GetViaSubscriptionDetailAsync(Guid firmGuid, string subscriptionCode);

    /// <summary>KVK onay durumu. Rate Limit: 100/dk</summary>
    Task<KvkConsentStatusResponse?> GetKvkConsentStatusAsync(Guid firmGuid, GetKvkConsentStatusRequest request);

    /// <summary>KVK izin ekleme. Rate Limit: 50/dk</summary>
    Task<KvkConsentResponse?> AddKvkConsentAsync(Guid firmGuid, AddKvkConsentRequest request);

    /// <summary>ViaPass kod gönderme. Rate Limit: 50/dk</summary>
    Task<ViaPassSendResponse?> SendViaPassAsync(Guid firmGuid, SendViaPassRequest request);

    /// <summary>ViaPass doğrulama. Rate Limit: 50/dk</summary>
    Task<ViaPassVerifyResponse?> VerifyViaPassAsync(Guid firmGuid, VerifyViaPassRequest request);

    /// <summary>ViaFrame URL üretme. Rate Limit: 50/dk</summary>
    Task<ViaFrameUrlResponse?> GenerateViaFrameUrlAsync(Guid firmGuid, GenerateViaFrameUrlRequest request);

    /// <summary>ViaFrame sonuç sorgulama. Rate Limit: 50/dk</summary>
    Task<ViaFrameResultResponse?> GetViaFrameResultAsync(Guid firmGuid, string token);
}
