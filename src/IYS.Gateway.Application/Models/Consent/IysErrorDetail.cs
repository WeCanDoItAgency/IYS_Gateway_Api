namespace IYS.Gateway.Application.Models.Consent;

/// <summary>
/// IYS API hata detay modeli.
/// Hem Application hem Infrastructure katmanında kullanılır.
/// </summary>
public class IysErrorDetail
{
    /// <summary>Hata kodu (ör: H121, H120)</summary>
    public string? Code { get; set; }

    /// <summary>Hata mesajı</summary>
    public string? Message { get; set; }
}
