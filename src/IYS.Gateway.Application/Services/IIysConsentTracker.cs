using IYS.Gateway.Application.Models.Consent;

namespace IYS.Gateway.Application.Services;

/// <summary>
/// IYS izin takip servisi.
/// Her izin ekleme/sorgulama sonrası MongoDB IysRequestConsentMongo kaydını günceller.
/// Tüm kanallardan (ekran, API, Hangfire) gelen işlemler bu servis üzerinden izlenir.
/// </summary>
public interface IIysConsentTracker
{
    /// <summary>
    /// İzin ekleme sonrası MongoDB kaydını oluşturur veya günceller.
    /// TransactionId, Status, Errors gibi IYS API yanıtlarını kaydeder.
    /// </summary>
    /// <param name="firmId">Firma ID</param>
    /// <param name="recipient">Alıcı (telefon veya email)</param>
    /// <param name="type">İzin türü: ARAMA / MESAJ / EPOSTA</param>
    /// <param name="recipientType">Alıcı tipi: BIREYSEL / TACIR</param>
    /// <param name="source">İzin kaynağı: WEB, HS_WEB vb.</param>
    /// <param name="consentDate">İzin tarihi</param>
    /// <param name="transactionId">IYS'den dönen işlem ID'si</param>
    /// <param name="status">İzin durumu: ONAY / RET</param>
    /// <param name="iysCreationDate">IYS'deki oluşturma tarihi</param>
    /// <param name="errors">IYS API hataları</param>
    Task UpsertConsentRecordAsync(
        int firmId,
        string recipient,
        string type,
        string recipientType,
        string? source,
        string? consentDate,
        string? transactionId,
        string? status,
        DateTime? iysCreationDate = null,
        List<IysErrorDetail>? errors = null);

    /// <summary>
    /// İzin durum sorgulama sonrası mevcut MongoDB kaydının status'ünü günceller.
    /// </summary>
    /// <param name="firmId">Firma ID</param>
    /// <param name="recipient">Alıcı</param>
    /// <param name="type">İzin türü</param>
    /// <param name="status">Yeni durum: ONAY / RET</param>
    /// <param name="source">Kaynak</param>
    /// <param name="transactionId">İşlem ID</param>
    /// <param name="consentDate">İzin tarihi</param>
    Task UpdateConsentStatusAsync(
        int firmId,
        string recipient,
        string type,
        string? status,
        string? source = null,
        string? transactionId = null,
        string? consentDate = null);
}
