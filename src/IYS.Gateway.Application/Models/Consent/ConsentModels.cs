using System.ComponentModel.DataAnnotations;
using IYS.Gateway.Domain.Enums;

namespace IYS.Gateway.Application.Models.Consent;

// ═══════════════════════════════════════════════════════════════
// TEKİL İZİN EKLEME
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Tekil izin ekleme istek modeli.
/// </summary>
public class AddSingleConsentRequest
{
    /// <summary>İzin türü. ARAMA | MESAJ | EPOSTA</summary>
    /// <example>MESAJ</example>
    [Required]
    [IysEnum(typeof(ConsentType))]
    public string Type { get; set; } = default!;

    /// <summary>Alıcı iletişim bilgisi. Telefon: +905XXXXXXXXX, E-posta: xxx@xxx.com</summary>
    /// <example>+905001234567</example>
    [Required]
    public string Recipient { get; set; } = default!;

    /// <summary>Alıcı tipi. BIREYSEL | TACIR</summary>
    /// <example>BIREYSEL</example>
    [Required]
    [IysEnum(typeof(Domain.Enums.RecipientType))]
    public string RecipientType { get; set; } = default!;

    /// <summary>İzin durumu. ONAY | RET</summary>
    /// <example>ONAY</example>
    [Required]
    [IysEnum(typeof(ConsentStatus))]
    public string Status { get; set; } = default!;

    /// <summary>İzin tarihi. Format: yyyy-MM-dd HH:mm:ss</summary>
    /// <example>2024-01-15 10:30:00</example>
    [Required]
    public string ConsentDate { get; set; } = default!;

    /// <summary>İzin kaynağı. HS_WEB, HS_CAGRI_MERKEZI, HS_FIZIKSEL_ORTAM vb.</summary>
    /// <example>HS_WEB</example>
    [Required]
    [IysEnum(typeof(ConsentSource))]
    public string Source { get; set; } = default!;
}

// ═══════════════════════════════════════════════════════════════
// TOPLU İZİN EKLEME
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Toplu izin ekleme istek modeli. Maksimum 10.000 kayıt.
/// </summary>
public class AddBatchConsentRequest
{
    /// <summary>İzin kayıtları listesi. Minimum 1, maksimum 10.000 kayıt.</summary>
    [Required]
    public List<AddSingleConsentRequest> Consents { get; set; } = new();
}

// ═══════════════════════════════════════════════════════════════
// TEKİL İZİN DURUM SORGULAMA
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Tekil izin durum sorgulama istek modeli.
/// </summary>
public class GetConsentStatusRequest
{
    /// <summary>Alıcı iletişim bilgisi. Telefon: +905XXXXXXXXX, E-posta: xxx@xxx.com</summary>
    /// <example>+905001234567</example>
    [Required]
    public string Recipient { get; set; } = default!;

    /// <summary>Alıcı tipi. BIREYSEL | TACIR</summary>
    /// <example>BIREYSEL</example>
    [Required]
    [IysEnum(typeof(Domain.Enums.RecipientType))]
    public string RecipientType { get; set; } = default!;

    /// <summary>İzin türü. ARAMA | MESAJ | EPOSTA</summary>
    /// <example>MESAJ</example>
    [Required]
    [IysEnum(typeof(ConsentType))]
    public string Type { get; set; } = default!;
}

// ═══════════════════════════════════════════════════════════════
// ÇOKLU İZİN DURUM SORGULAMA
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Çoklu izin durum sorgulama istek modeli. Maksimum 1.000 alıcı.
/// </summary>
public class GetMultipleConsentStatusRequest
{
    /// <summary>Alıcı iletişim bilgisi listesi. Maksimum 1.000 kayıt.</summary>
    /// <example>["+905001234567", "+905009876543"]</example>
    [Required]
    public List<string> Recipients { get; set; } = new();
}

// ═══════════════════════════════════════════════════════════════
// İZİN GEÇMİŞİ
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// İzin geçmişi sorgulama istek modeli.
/// </summary>
public class GetConsentHistoryRequest
{
    /// <summary>Alıcı iletişim bilgisi</summary>
    /// <example>+905001234567</example>
    [Required]
    public string Recipient { get; set; } = default!;

    /// <summary>Alıcı tipi. BIREYSEL | TACIR</summary>
    /// <example>BIREYSEL</example>
    [Required]
    [IysEnum(typeof(Domain.Enums.RecipientType))]
    public string RecipientType { get; set; } = default!;

    /// <summary>İzin türü. ARAMA | MESAJ | EPOSTA</summary>
    /// <example>MESAJ</example>
    [Required]
    [IysEnum(typeof(ConsentType))]
    public string Type { get; set; } = default!;
}

// ═══════════════════════════════════════════════════════════════
// PUSH BİLDİRİM
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Push bildirim kayıt istek modeli.
/// </summary>
public class RegisterPushRequest
{
    /// <summary>Push bildirimlerinin gönderileceği URL</summary>
    /// <example>https://example.com/iys/webhook</example>
    [Required]
    public string Url { get; set; } = default!;

    /// <summary>Push bildirim tipi. CONSENT_CHANGE</summary>
    /// <example>CONSENT_CHANGE</example>
    [Required]
    public string Type { get; set; } = default!;
}

/// <summary>
/// Push bildirim silme istek modeli.
/// </summary>
public class UnregisterPushRequest
{
    /// <summary>Silinecek push bildirim tipi</summary>
    /// <example>CONSENT_CHANGE</example>
    [Required]
    public string Type { get; set; } = default!;
}
