namespace IYS.Gateway.Application.Common;

/// <summary>
/// Firma bazlı IYS bağlamı. Token, credentials ve brandCode bilgilerini tek nesnede taşır.
/// Her request için FirmGuid'den resolve edilir.
/// </summary>
public class IysFirmContext
{
    /// <summary>Firmanın benzersiz tanımlayıcısı</summary>
    public Guid FirmGuid { get; set; }

    /// <summary>Firmanın MSSQL Id'si</summary>
    public int FirmId { get; set; }

    /// <summary>Firma adı (log amaçlı)</summary>
    public string FirmName { get; set; } = null!;

    /// <summary>IYS müşteri kodu — API path parametrelerinde {iysCode} olarak kullanılır</summary>
    public int IysCode { get; set; }

    /// <summary>IYS marka kodu — API path parametrelerinde {brandCode} olarak kullanılır</summary>
    public int BrandCode { get; set; }

    /// <summary>Aktif access token</summary>
    public string AccessToken { get; set; } = null!;
}
