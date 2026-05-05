using System.Text.Json.Serialization;
using IYS.Gateway.Application.Models.Common;

namespace IYS.Gateway.Application.Models.Via;

// ═══════════════════════════════════════════════════════════════
// VIA / KVK / ViaPass / ViaFrame Response Modelleri
// OpenAPI v1 spec'ten türetilmiştir. object/dynamic YASAKTIR.
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// ViA abonelik bilgisi.
/// GET /sps/{iysCode}/brands/{brandCode}/via/subscriptions
/// OpenAPI: SubscriptionResponseDTO (9 property)
/// </summary>
public class ViaSubscriptionItem
{
    [JsonPropertyName("iysViaSubscriptionId")]
    public string? IysViaSubscriptionId { get; set; }

    [JsonPropertyName("iysCode")]
    public int? IysCode { get; set; }

    [JsonPropertyName("startDate")]
    public string? StartDate { get; set; }

    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    [JsonPropertyName("lastUpdateDate")]
    public string? LastUpdateDate { get; set; }

    [JsonPropertyName("autoRenewal")]
    public bool? AutoRenewal { get; set; }

    [JsonPropertyName("viaCredit")]
    public int? ViaCredit { get; set; }

    [JsonPropertyName("viaSubscriptionPackage")]
    public ViaSubscriptionPackageItem? ViaSubscriptionPackage { get; set; }
}

/// <summary>
/// ViA abonelik paket detayı.
/// OpenAPI: ViaSubscriptionPackageDTO (7 property)
/// </summary>
public class ViaSubscriptionPackageItem
{
    [JsonPropertyName("viaSubscriptionId")]
    public string? ViaSubscriptionId { get; set; }

    [JsonPropertyName("startDate")]
    public string? StartDate { get; set; }

    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("viaSubscriptionPackageName")]
    public string? ViaSubscriptionPackageName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("viaCredit")]
    public int? ViaCredit { get; set; }

    [JsonPropertyName("isLimited")]
    public bool? IsLimited { get; set; }
}

/// <summary>
/// KVK izin durumu yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/kvk/consents/status
/// </summary>
public class KvkConsentStatusResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// KVK izin ekleme yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/kvk/consents
/// </summary>
public class KvkConsentResponse
{
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// ViaPass gönderme yanıtı.
/// </summary>
public class ViaPassSendResponse
{
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// ViaPass doğrulama yanıtı.
/// </summary>
public class ViaPassVerifyResponse
{
    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// ViaFrame URL üretme yanıtı.
/// </summary>
public class ViaFrameUrlResponse
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// ViaFrame sonuç sorgulama yanıtı.
/// </summary>
public class ViaFrameResultResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}
