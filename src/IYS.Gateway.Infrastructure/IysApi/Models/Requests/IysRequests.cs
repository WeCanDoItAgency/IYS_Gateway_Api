using System.Text.Json.Serialization;

namespace IYS.Gateway.Infrastructure.IysApi.Models.Requests;

/// <summary>
/// IYS tekil izin ekleme isteği.
/// POST /sps/{iysCode}/brands/{brandCode}/consents
/// Rate Limit: Dakikada 50 istek
/// 
/// Kısıtlar:
/// - İlk izin kaydında status RET olamaz.
/// - consentDate 3 iş gününden eski olamaz.
/// - recipient telefon formatı: +905XXXXXXXXX
/// </summary>
public class ConsentRequest
{
    /// <summary>İzin tipi: ARAMA, MESAJ veya EPOSTA</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>İzin kaynağı: HS_WEB, HS_CAGRI_MERKEZI, HS_FIZIKSEL_ORTAM vb.</summary>
    [JsonPropertyName("source")]
    public string Source { get; set; } = null!;

    /// <summary>Alıcı adresi. Telefon: +905XXXXXXXXX, E-posta: ornek@sirket.com</summary>
    [JsonPropertyName("recipient")]
    public string Recipient { get; set; } = null!;

    /// <summary>Alıcı tipi: BIREYSEL veya TACIR</summary>
    [JsonPropertyName("recipientType")]
    public string RecipientType { get; set; } = null!;

    /// <summary>İzin durumu: ONAY veya RET</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    /// <summary>İzin tarihi. Format: yyyy-MM-dd HH:mm:ss. 3 iş gününden eski olamaz.</summary>
    [JsonPropertyName("consentDate")]
    public string ConsentDate { get; set; } = null!;
}

/// <summary>
/// İzin durumu sorgulama isteği.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/status
/// Rate Limit: Dakikada 100 istek
/// </summary>
public class ConsentStatusRequest
{
    /// <summary>Alıcı adresi (telefon veya e-posta)</summary>
    [JsonPropertyName("recipient")]
    public string Recipient { get; set; } = null!;

    /// <summary>Alıcı tipi: BIREYSEL veya TACIR</summary>
    [JsonPropertyName("recipientType")]
    public string RecipientType { get; set; } = null!;

    /// <summary>İzin tipi: ARAMA, MESAJ veya EPOSTA</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
}

/// <summary>
/// Çoklu izin durumu sorgulama isteği.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/{recipientType}/status/{type}
/// Rate Limit: Dakikada 10 istek, maksimum 1.000 alıcı/istek
/// </summary>
public class MultipleConsentStatusRequest
{
    /// <summary>Alıcı adresleri listesi (telefon veya e-posta). Maksimum 1.000 adet.</summary>
    [JsonPropertyName("recipients")]
    public List<string> Recipients { get; set; } = new();
}

/// <summary>
/// İzin geçmişi sorgulama isteği.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/history
/// Rate Limit: Dakikada 100 istek
/// </summary>
public class ConsentHistoryRequest
{
    /// <summary>Alıcı adresi</summary>
    [JsonPropertyName("recipient")]
    public string Recipient { get; set; } = null!;

    /// <summary>Alıcı tipi: BIREYSEL veya TACIR</summary>
    [JsonPropertyName("recipientType")]
    public string RecipientType { get; set; } = null!;

    /// <summary>İzin tipi: ARAMA, MESAJ veya EPOSTA</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
}

/// <summary>
/// Toplu izin ekleme isteğindeki tekil izin.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/request
/// Maksimum 10.000 kayıt/istek
/// </summary>
public class BatchConsentRequest
{
    /// <summary>Toplu izin listesi. Maksimum 10.000 adet.</summary>
    [JsonPropertyName("consents")]
    public List<ConsentRequest> Consents { get; set; } = new();
}
