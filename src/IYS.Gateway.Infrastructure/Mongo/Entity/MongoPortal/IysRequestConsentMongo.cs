using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// IYS izin takip kaydı. Her bir alıcı + firma + izin tipi için MongoDB'de tutulan merkezi kayıt.
/// MONGO_52 / IysRequestConsent collection'ında saklanır.
/// Hem ekrandan hem API'den gelen tüm izin işlemlerinin durumu bu entity üzerinden izlenir.
/// </summary>
[BsonCollection("iysrequestconsentmongo")]
[BsonIgnoreExtraElements]
public class IysRequestConsentMongo : MongoDbEntity
{

    /// <summary>İzin tarihi (yyyy-MM-dd HH:mm:ss formatında)</summary>
    public string? ConsentDate { get; set; }

    /// <summary>İzin kaynağı: WEB, HS_WEB, FIZIKSEL_ORTAM vb.</summary>
    public string? Source { get; set; }

    /// <summary>Alıcı: +905XXXXXXXXX veya email adresi</summary>
    public string? Recipient { get; set; }

    /// <summary>Alıcı tipi: BIREYSEL / TACIR</summary>
    public string? RecipientType { get; set; }

    /// <summary>İzin durumu: ONAY / RET</summary>
    public string? Status { get; set; }

    /// <summary>İzin türü: ARAMA / MESAJ / EPOSTA</summary>
    public string? Type { get; set; }

    /// <summary>IYS'den dönen perakendeci kodu</summary>
    public int? RetailerCode { get; set; }

    /// <summary>IYS'den dönen perakendeci başlığı</summary>
    public string? RetailerTitle { get; set; }

    /// <summary>Perakendeci erişim sayısı</summary>
    public int RetailerAccessCount { get; set; }

    /// <summary>IYS'den dönen işlem ID'si — null ise henüz IYS'ye gönderilmemiş</summary>
    public string? TransactionId { get; set; }

    /// <summary>Perakendeci erişim ID listesi</summary>
    public List<int> RetailerAccess { get; set; } = new();

    /// <summary>Kullanıcı kimlik bilgisi ID'si</summary>
    public int UserCredentialId { get; set; }

    /// <summary>IYS API'den dönen hata detayları</summary>
    public List<IysErrorDetail>? Errors { get; set; }

    /// <summary>IYS'deki oluşturma tarihi</summary>
    public DateTime? IysCreationDate { get; set; }

    /// <summary>Son sorgu/güncelleme zamanı</summary>
    public DateTime? LastQueryDate { get; set; }

    /// <summary>Firma ID (MSSQL NewFirms.Id)</summary>
    public int? FirmId { get; set; }

    /// <summary>CariKart referansı (MSSQL NewCariKartlar.Id)</summary>
    public int? NewCariKartId { get; set; }

    /// <summary>MSSQL UserAgreementLogs.Id referansı</summary>
    public int? MssqlId { get; set; }

    /// <summary>TCKN veya Pasaport numarası</summary>
    public string? IdentityNumber { get; set; }
}
