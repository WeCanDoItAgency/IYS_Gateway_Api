namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// İzin tipi. IYS API'de izin eklerken veya sorgularken kullanılan iletişim kanalı türünü belirtir.
/// </summary>
public static class ConsentType
{
    /// <summary>Telefon araması kanalı</summary>
    public const string ARAMA = "ARAMA";

    /// <summary>SMS mesaj kanalı</summary>
    public const string MESAJ = "MESAJ";

    /// <summary>E-posta kanalı</summary>
    public const string EPOSTA = "EPOSTA";
}
