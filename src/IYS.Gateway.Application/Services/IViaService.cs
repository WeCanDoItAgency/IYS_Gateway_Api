namespace IYS.Gateway.Application.Services;

/// <summary>
/// ViA, KVK, ViaPass, ViaFrame servis arayüzü.
/// </summary>
public interface IViaService
{
    /// <summary>ViA abonelik listesi. Rate Limit: 50/dk</summary>
    Task<object?> GetViaSubscriptionsAsync(Guid firmGuid);

    /// <summary>ViA abonelik detayı. Rate Limit: 50/dk</summary>
    Task<object?> GetViaSubscriptionDetailAsync(Guid firmGuid, string subscriptionCode);

    /// <summary>KVK onay durumu. Rate Limit: 100/dk</summary>
    Task<object?> GetKvkConsentStatusAsync(Guid firmGuid, object body);

    /// <summary>KVK izin ekleme. Rate Limit: 50/dk</summary>
    Task<object?> AddKvkConsentAsync(Guid firmGuid, object body);

    /// <summary>ViaPass kod gönderme. Rate Limit: 50/dk</summary>
    Task<object?> SendViaPassAsync(Guid firmGuid, object body);

    /// <summary>ViaPass doğrulama. Rate Limit: 50/dk</summary>
    Task<object?> VerifyViaPassAsync(Guid firmGuid, object body);

    /// <summary>ViaFrame URL üretme. Rate Limit: 50/dk</summary>
    Task<object?> GenerateViaFrameUrlAsync(Guid firmGuid, object body);

    /// <summary>ViaFrame sonuç sorgulama. Rate Limit: 50/dk</summary>
    Task<object?> GetViaFrameResultAsync(Guid firmGuid, string token);
}
