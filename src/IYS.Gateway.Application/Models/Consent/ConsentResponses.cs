using System.Text.Json.Serialization;
using IYS.Gateway.Application.Models.Common;

namespace IYS.Gateway.Application.Models.Consent;

// ═══════════════════════════════════════════════════════════════
// IYS API RESPONSE MODELLERİ
// OpenAPI v1 spec'ten türetilmiştir. object/dynamic YASAKTIR.
// Hata detayı: IysErrorDetail (Common/ altında tek kaynak)
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// IYS genel hata yanıtı. Tüm IYS API hatalarında bu formatta döner.
/// </summary>
public class IysErrorResponse
{
    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// Tekil izin ekleme yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents
/// OpenAPI: AddConsentResponseMessage
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
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// Toplu izin ekleme yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/request
/// OpenAPI: AddMultipleConsentResponse
/// </summary>
public class BatchConsentResponse
{
    /// <summary>Asenkron işlem takip numarası</summary>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    /// <summary>Her izin kaydı için atanan alt istek bilgileri</summary>
    [JsonPropertyName("subRequests")]
    public List<SubRequestItem>? SubRequests { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// Çoklu izin ekleme yanıtındaki alt istek detayı.
/// OpenAPI: MultipleConsentsSubRequests
/// </summary>
public class SubRequestItem
{
    /// <summary>Alt istek takip numarası</summary>
    [JsonPropertyName("subrequestId")]
    public string? SubRequestId { get; set; }

    /// <summary>İzin tipi (ARAMA, MESAJ, EPOSTA)</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>İzin kaynağı</summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>Alıcı adresi</summary>
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    /// <summary>İzin durumu (ONAY, RET)</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>İzin tarihi</summary>
    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    /// <summary>Alıcı tipi (BIREYSEL, TACIR)</summary>
    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    /// <summary>İznin IYS'ye kaydedilme tarihi</summary>
    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }
}

/// <summary>
/// İzin durumu sorgulama yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/status
/// OpenAPI: ResponseConsentStatus
/// </summary>
public class ConsentStatusResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("retailerCode")]
    public int? RetailerCode { get; set; }

    [JsonPropertyName("retailerTitle")]
    public string? RetailerTitle { get; set; }

    [JsonPropertyName("retailerAccessCount")]
    public int? RetailerAccessCount { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// Çoklu izin durumu sorgulama yanıtı.
/// POST /sps/{iysCode}/brands/{brandCode}/consents/{recipientType}/status/{type}
/// </summary>
public class MultipleConsentStatusResponse
{
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    /// <summary>ONAY durumunda olan alıcı listesi</summary>
    [JsonPropertyName("list")]
    public List<string>? List { get; set; }

    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
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
    public List<IysErrorDetail>? Errors { get; set; }

    public bool IsSuccessfull => Errors == null || Errors.Count == 0;
    public int StatusCode { get; set; }
}

/// <summary>
/// İzin geçmişi tekil kayıt.
/// </summary>
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

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }
}

/// <summary>
/// Sayfalama bilgisi (consent history, changes gibi endpoint'ler için).
/// OpenAPI: SearchPagination (offset-based)
/// </summary>
public class PaginationInfo
{
    /// <summary>Başlangıç offset'i</summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    /// <summary>Sayfa boyutu</summary>
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    /// <summary>Toplam kayıt sayısı</summary>
    [JsonPropertyName("totalCount")]
    public int? TotalCount { get; set; }
}

/// <summary>
/// Sayfalama bilgisi (ViaPass, request process history gibi endpoint'ler için).
/// OpenAPI: Pagination (page-based)
/// </summary>
public class PageBasedPaginationInfo
{
    [JsonPropertyName("currentPage")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("elementsInPage")]
    public int? ElementsInPage { get; set; }

    [JsonPropertyName("totalItems")]
    public int? TotalItems { get; set; }

    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }
}

/// <summary>
/// Toplu izin sonuç sorgulama tekil kayıt.
/// GET /sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}
/// OpenAPI: ResponseBulkImportResult
/// </summary>
public class BatchConsentStatusItem
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subrequestId")]
    public string? SubRequestId { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    /// <summary>Hata detayı (tekil, başarısız kayıt için)</summary>
    [JsonPropertyName("error")]
    public IysErrorDetail? Error { get; set; }

    /// <summary>Hata listesi</summary>
    [JsonPropertyName("errors")]
    public List<IysErrorDetail>? Errors { get; set; }
}

/// <summary>
/// İzin değişiklikleri yanıtı.
/// GET /sps/{iysCode}/brands/{brandCode}/consents/changes
/// OpenAPI: after (cursor) + list (değişiklik kayıtları)
/// </summary>
public class ConsentChangesResponse
{
    /// <summary>Sonraki sorgu için cursor değeri</summary>
    [JsonPropertyName("after")]
    public string? After { get; set; }

    /// <summary>Değişiklik kayıtları listesi</summary>
    [JsonPropertyName("list")]
    public List<ConsentChangeResponseItem>? List { get; set; }
}

/// <summary>
/// İzin değişiklik tekil kayıt.
/// EGM: ConsentChangeItem
/// </summary>
public class ConsentChangeResponseItem
{
    [JsonPropertyName("consentDate")]
    public string? ConsentDate { get; set; }

    [JsonPropertyName("creationDate")]
    public string? CreationDate { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }
}
