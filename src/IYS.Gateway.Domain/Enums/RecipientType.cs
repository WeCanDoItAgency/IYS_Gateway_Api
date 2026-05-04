namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// Alıcı tipi. IYS API'de izin kaydı eklerken veya sorgularken kullanılan alıcı türünü belirtir.
/// Bireysel ve tacir ayrımı yapılır.
/// </summary>
public static class RecipientType
{
    /// <summary>Bireysel alıcı — Gerçek kişi</summary>
    public const string BIREYSEL = "BIREYSEL";

    /// <summary>Tacir alıcı — Tüzel kişi</summary>
    public const string TACIR = "TACIR";
}
