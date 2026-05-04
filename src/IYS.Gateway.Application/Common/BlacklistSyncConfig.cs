namespace IYS.Gateway.Application.Common;

/// <summary>
/// Karaliste senkronizasyon yapılandırması.
/// EnableSqlSync false yapıldığında SQL yazımı devre dışı kalır (SQL kapatma planı).
/// </summary>
public class BlacklistSyncConfig
{
    public const string SectionName = "BlacklistSync";

    /// <summary>MSSQL BusinessRulesLog tablosuna yazılsın mı? (SQL kapatılabilirlik)</summary>
    public bool EnableSqlSync { get; set; } = true;

    /// <summary>MongoDB IysRequestConsentMongo takibi aktif mi?</summary>
    public bool EnableMongoTracking { get; set; } = true;
}
