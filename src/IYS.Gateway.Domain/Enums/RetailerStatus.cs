namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// Bayi durumu. IYS API'de bayi kaydı oluştururken veya sorgularken kullanılan durum bilgisi.
/// </summary>
public static class RetailerStatus
{
    /// <summary>Aktif bayi</summary>
    public const string ACTIVE = "active";

    /// <summary>Pasif bayi</summary>
    public const string PASSIVE = "passive";

    /// <summary>Askıya alınmış bayi</summary>
    public const string SUSPENDED = "suspended";
}
