using System.ComponentModel.DataAnnotations;
using IYS.Gateway.Domain.Enums;

namespace IYS.Gateway.Application.Models.Via;

/// <summary>
/// KVK onay durumu sorgulama istek modeli.
/// </summary>
public class GetKvkConsentStatusRequest
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
}

/// <summary>
/// KVK izin ekleme istek modeli.
/// </summary>
public class AddKvkConsentRequest
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

    /// <summary>İzin durumu. ONAY | RET</summary>
    /// <example>ONAY</example>
    [Required]
    [IysEnum(typeof(ConsentStatus))]
    public string Status { get; set; } = default!;

    /// <summary>İzin tarihi. Format: yyyy-MM-dd HH:mm:ss</summary>
    /// <example>2024-01-15 10:30:00</example>
    [Required]
    public string ConsentDate { get; set; } = default!;
}

/// <summary>
/// ViaPass kod gönderme istek modeli.
/// </summary>
public class SendViaPassRequest
{
    /// <summary>Doğrulama kodu gönderilecek telefon numarası</summary>
    /// <example>+905001234567</example>
    [Required]
    public string Phone { get; set; } = default!;
}

/// <summary>
/// ViaPass doğrulama istek modeli.
/// </summary>
public class VerifyViaPassRequest
{
    /// <summary>Doğrulama kodu</summary>
    /// <example>123456</example>
    [Required]
    public string Code { get; set; } = default!;

    /// <summary>Telefon numarası</summary>
    /// <example>+905001234567</example>
    [Required]
    public string Phone { get; set; } = default!;
}

/// <summary>
/// ViaFrame URL üretme istek modeli.
/// </summary>
public class GenerateViaFrameUrlRequest
{
    /// <summary>Form tamamlandıktan sonra yönlendirilecek URL</summary>
    /// <example>https://example.com/callback</example>
    [Required]
    public string ReturnUrl { get; set; } = default!;

    /// <summary>Form tipi</summary>
    /// <example>CONSENT</example>
    [Required]
    public string Type { get; set; } = default!;
}
