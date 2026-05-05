using System.Text.Json.Serialization;

namespace IYS.Gateway.Application.Models.Brand;

// ═══════════════════════════════════════════════════════════════
// IYS Marka / Bayi / Kaynak / Mutabakat Response Modelleri
// OpenAPI v1 spec'ten türetilmiştir. object/dynamic YASAKTIR.
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Marka listesi item'ı.
/// GET /sps/{iysCode}/brands → List&lt;BrandItem&gt; (array döner)
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
/// Marka detayı (tek marka bilgisi).
/// GET /sps/{iysCode}/brands/{brandCode}
/// </summary>
public class BrandDetailResponse
{
    [JsonPropertyName("brandCode")]
    public int BrandCode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("master")]
    public bool? Master { get; set; }

    [JsonPropertyName("iysCode")]
    public int? IysCode { get; set; }
}

/// <summary>
/// Bayi bilgisi.
/// GET /sps/{iysCode}/brands/{brandCode}/retailers → List&lt;RetailerItem&gt;
/// OpenAPI: RetailerSearchList (12 property)
/// </summary>
public class RetailerItem
{
    [JsonPropertyName("retailerCode")]
    public int RetailerCode { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("mersis")]
    public string? Mersis { get; set; }

    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("tckn")]
    public string? Tckn { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    [JsonPropertyName("city")]
    public CodeNameItem? City { get; set; }

    [JsonPropertyName("town")]
    public CodeNameItem? Town { get; set; }

    [JsonPropertyName("retailerAccessCount")]
    public int? RetailerAccessCount { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tin")]
    public string? Tin { get; set; }
}

/// <summary>
/// İl/İlçe kod-isim çifti.
/// OpenAPI: Code-Name
/// </summary>
public class CodeNameItem
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

/// <summary>
/// İzin sayısı mutabakat yanıtı.
/// GET /sps/{iysCode}/brands/{brandCode}/consents/count
/// </summary>
public class ConsentCountResponse
{
    /// <summary>ONAY durumundaki toplam izin sayısı</summary>
    [JsonPropertyName("approvedCount")]
    public long? ApprovedCount { get; set; }

    /// <summary>RET durumundaki toplam izin sayısı</summary>
    [JsonPropertyName("rejectedCount")]
    public long? RejectedCount { get; set; }

    /// <summary>Toplam izin kayıt sayısı</summary>
    [JsonPropertyName("totalCount")]
    public long? TotalCount { get; set; }
}

/// <summary>
/// IYS kaynak bilgisi.
/// GET /sps/sources → List&lt;IysSourceItem&gt;
/// </summary>
public class IysSourceItem
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
