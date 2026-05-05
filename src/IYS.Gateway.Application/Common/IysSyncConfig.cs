namespace IYS.Gateway.Application.Common;

/// <summary>
/// IYS senkronizasyon yapılandırması.
/// appsettings.json → "IysSync" section'ından okunur.
/// MongoDB tracking her zaman aktiftir (toggle yoktur).
/// UseSqlDb false yapıldığında tüm MSSQL erişimi devre dışı kalır.
/// </summary>
public class IysSyncConfig
{
    public const string SectionName = "IysSync";

    /// <summary>SQL anahtarı: false olunca tüm MSSQL operasyonları (BlacklistSync) devre dışı</summary>
    public bool UseSqlDb { get; set; } = true;
}
