namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// Toplu izin ekleme sonuç durumu. Asenkron batch işlem sonucunda her kayıt için döner.
/// </summary>
public static class BatchConsentStatus
{
    /// <summary>İzin başarıyla kaydedildi</summary>
    public const string SUCCESS = "success";

    /// <summary>İzin kaydı başarısız</summary>
    public const string FAILURE = "failure";

    /// <summary>İzin kuyruğa alındı, işleniyor</summary>
    public const string ENQUEUE = "enqueue";
}
