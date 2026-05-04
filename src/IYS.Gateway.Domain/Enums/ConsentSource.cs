namespace IYS.Gateway.Domain.Enums;

/// <summary>
/// İzin kaynağı. IYS API'de izin kaydı eklerken iznin hangi kanaldan alındığını belirtir.
/// </summary>
public static class ConsentSource
{
    /// <summary>Fiziksel ortam (ıslak imza vb.)</summary>
    public const string HS_FIZIKSEL_ORTAM = "HS_FIZIKSEL_ORTAM";

    /// <summary>Elektronik ortam — Web sitesi üzerinden</summary>
    public const string HS_WEB = "HS_WEB";

    /// <summary>Elektronik ortam — Çağrı merkezi üzerinden</summary>
    public const string HS_CAGRI_MERKEZI = "HS_CAGRI_MERKEZI";

    /// <summary>Elektronik ortam — Sosyal medya üzerinden</summary>
    public const string HS_SOSYAL_MEDYA = "HS_SOSYAL_MEDYA";

    /// <summary>Elektronik ortam — E-posta üzerinden</summary>
    public const string HS_EPOSTA = "HS_EPOSTA";

    /// <summary>Elektronik ortam — Mesaj üzerinden</summary>
    public const string HS_MESAJ = "HS_MESAJ";

    /// <summary>Elektronik ortam — Mobil uygulama üzerinden</summary>
    public const string HS_MOBIL = "HS_MOBIL";

    /// <summary>Elektronik ortam — HS_EORTAM (Genel elektronik ortam)</summary>
    public const string HS_EORTAM = "HS_EORTAM";

    /// <summary>Etkinlik ortamı üzerinden</summary>
    public const string HS_ETKINLIK = "HS_ETKINLIK";

    /// <summary>Mağaza, bayi gibi fiziksel satış noktaları üzerinden</summary>
    public const string HS_2015 = "HS_2015";

    /// <summary>Alıcının kendisinin HS_ATM üzerinden onayı</summary>
    public const string HS_ATM = "HS_ATM";

    /// <summary>Islak imza ile fiziksel ortamda alınan izin</summary>
    public const string HS_ISLAK_IMZA = "HS_ISLAK_IMZA";

    /// <summary>Mahkeme/Kurul kararı ile otomatik onay</summary>
    public const string HS_KARAR = "HS_KARAR";
}
