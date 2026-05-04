namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// İzin durumu. IYS API'de izin kaydı eklerken veya sorgularken kullanılan onay/ret durumunu belirtir.
/// </summary>
public static class ConsentStatus
{
    /// <summary>İzin onaylandı — Alıcı ticari elektronik ileti almayı kabul etti.</summary>
    public const string ONAY = "ONAY";

    /// <summary>İzin reddedildi — Alıcı ticari elektronik ileti almayı reddetti.</summary>
    public const string RET = "RET";
}
