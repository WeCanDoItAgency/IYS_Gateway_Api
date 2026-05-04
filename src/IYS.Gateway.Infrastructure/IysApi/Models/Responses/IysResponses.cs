using System.Text.Json;
using System.Text.Json.Serialization;

namespace IYS.Gateway.Infrastructure.IysApi.Models.Responses;

/// <summary>
/// IYS OAuth2 token yanıtı.
/// Token alma: grant_type=password ile username/password gönderilir.
/// Token yenileme: grant_type=refresh_token ile refresh_token gönderilir.
/// Rate Limit: IP başına saatte en fazla 10 istek.
/// </summary>
public class Oauth2Response
{
    /// <summary>API isteklerinde Authorization header'ında kullanılacak erişim jetonu</summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    /// <summary>Erişim jetonu süresi dolduğunda yenilemek için kullanılacak jeton</summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = null!;

    /// <summary>Erişim jetonunun geçerlilik süresi (saniye cinsinden). Varsayılan: 7200 (2 saat)</summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>Yenileme jetonunun geçerlilik süresi (saniye cinsinden). Varsayılan: 14400 (4 saat)</summary>
    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresIn { get; set; }

    /// <summary>Jeton tipi. Her zaman "bearer" döner.</summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "bearer";
}

/// <summary>
/// IYS Marka bilgisi.
/// GET /sps/{iysCode}/brands → Response: List&lt;BrandItem&gt; (array döner, wrapper obje YOK)
/// </summary>
public class BrandItem
{
    /// <summary>Marka kodu — API isteklerinde {brandCode} olarak kullanılır</summary>
    [JsonPropertyName("brandCode")]
    public int BrandCode { get; set; }

    /// <summary>Marka adı</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>Ana marka olup olmadığı</summary>
    [JsonPropertyName("master")]
    public bool? Master { get; set; }
}

/// <summary>
/// IYS genel hata yanıtı. Tüm IYS API hatalarında bu formatta döner.
/// </summary>
public class IysErrorResponse
{
    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

/// <summary>
/// IYS tekil hata detayı.
/// </summary>
public class IysError
{
    /// <summary>Hata kodu (ör: H001, H015, H085, H178)</summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>Hata açıklaması (Türkçe)</summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

/// <summary>
/// IYS tekil izin ekleme yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents
/// Başarılı ekleme sonucunda transactionId ve creationDate döner.
/// </summary>
public class ConsentResponse
{
    /// <summary>İşlem takip numarası</summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>İznin IYS'deki oluşturulma tarihi</summary>
    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    /// <summary>Hata listesi (başarısız olursa dolar)</summary>
    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

/// <summary>
/// IYS toplu izin ekleme yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/request
/// Asenkron işlem başlatır, requestId döner.
/// </summary>
public class BatchConsentResponse
{
    /// <summary>Asenkron işlem takip numarası — sonuç sorgulama için kullanılır</summary>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

/// <summary>
/// İzin durumu sorgulama yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/status
/// </summary>
public class ConsentStatusResponse
{
    /// <summary>İzin durumu: ONAY veya RET</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>İzin tipi (ARAMA, MESAJ, EPOSTA)</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Alıcı adresi</summary>
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    /// <summary>Alıcı tipi (BIREYSEL, TACIR)</summary>
    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    /// <summary>İznin alındığı tarih</summary>
    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    /// <summary>İzin kaydının IYS'ye eklenme tarihi</summary>
    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    /// <summary>İzin kaynağı (HS_WEB, HS_CAGRI_MERKEZI vb.)</summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>İşlem takip numarası</summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>Bayi erişim sayısı</summary>
    [JsonPropertyName("retailerAccessCount")]
    public int? RetailerAccessCount { get; set; }

    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

/// <summary>
/// Çoklu izin durumu sorgulama yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/{recipientType}/status/{type}
/// Rate Limit: Dakikada 10 istek, maksimum 1.000 alıcı/istek
/// </summary>
public class MultipleConsentStatusResponse
{
    /// <summary>İşlem takip numarası</summary>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    /// <summary>ONAY durumunda olan alıcı listesi</summary>
    [JsonPropertyName("list")]
    public List<string>? List { get; set; }

    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

/// <summary>
/// İzin geçmişi sorgulama yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/history
/// </summary>
public class ConsentHistoryResponse
{
    [JsonPropertyName("list")]
    public List<ConsentHistoryItem>? List { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationInfo? Pagination { get; set; }

    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }

    public bool IsSuccessfull => Errors == null || Errors.Count == 0;
    public int StatusCode { get; set; }
}

/// <summary>
/// IYS sayfalama bilgisi.
/// </summary>
public class PaginationInfo
{
    [JsonPropertyName("currentPage")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("totalPage")]
    public int? TotalPage { get; set; }

    [JsonPropertyName("totalRecord")]
    public int? TotalRecord { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }
}

/// <summary>
/// Toplu izin ekleme sonuç sorgulama yanıtı (array döner).
/// GET /sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}
/// </summary>
public class BatchConsentStatusItem
{
    /// <summary>İzin sırası</summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>İşlem durumu: success, failure, enqueue</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>İşlem takip numarası</summary>
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    /// <summary>Alıcı adresi</summary>
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    /// <summary>İzin oluşturulma tarihi</summary>
    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    [JsonPropertyName("errors")]
    public List<IysError>? Errors { get; set; }
}

public class ConsentHistoryItem
{
    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
