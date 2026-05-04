namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// ViA doğrulama yöntemi. İzin alma sürecinde kullanılan onay kanalını belirtir.
/// </summary>
public static class VerificationType
{
    /// <summary>SMS ile OTP doğrulama</summary>
    public const string SMS_OTP = "SMS_OTP";

    /// <summary>E-posta ile OTP doğrulama</summary>
    public const string EPOSTA_OTP = "EPOSTA_OTP";

    /// <summary>SMS ile kısa URL doğrulama</summary>
    public const string SMS_SHORTURL = "SMS_SHORTURL";

    /// <summary>E-posta ile kısa URL doğrulama</summary>
    public const string EPOSTA_SHORTURL = "EPOSTA_SHORTURL";

    /// <summary>E-posta ile onay URL'si doğrulama</summary>
    public const string EPOSTA_APPROVALURL = "EPOSTA_APPROVALURL";
}
