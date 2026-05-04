namespace IYS.Gateway.Application.Services;

/// <summary>
/// IYS karaliste/beyazliste senkronizasyon servisi.
/// MSSQL BusinessRulesLog tablosunu IYS izin durumuna göre günceller.
/// Config ile SQL yazımı kapatılabilir (SQL kapatma planı).
/// Manuel eklenen kayıtlara (CreatedUserId > 0) DOKUNULMAZ.
/// </summary>
public interface IBlacklistSyncService
{
    /// <summary>
    /// İzin durumuna göre karaliste/beyazliste senkronizasyonu yapar.
    /// ONAY → karaliste kaldır + beyazliste ekle
    /// RET → beyazliste kaldır + karaliste ekle
    /// </summary>
    /// <param name="status">İzin durumu: ONAY / RET</param>
    /// <param name="consentType">İzin türü: ARAMA / MESAJ / EPOSTA</param>
    /// <param name="recipient">Alıcı (telefon +90 prefixli veya email)</param>
    /// <param name="firmId">Firma ID</param>
    /// <returns>İşlem başarılı mı</returns>
    Task<bool> SyncBlacklistAsync(string? status, string consentType, string recipient, int firmId);
}
