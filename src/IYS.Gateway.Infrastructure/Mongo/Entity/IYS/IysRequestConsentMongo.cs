using IYS.Gateway.Application.Models.Common;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.IYS;

/// <summary>
/// IYS izin takip kaydı. MONGO_52 / iysrequestconsentmongo collection.
/// </summary>
[BsonCollection("iysrequestconsentmongo")]
[BsonIgnoreExtraElements]
public class IysRequestConsentMongo : MongoDbEntity
{
    public string? ConsentDate { get; set; }
    public string? Source { get; set; }
    public string? Recipient { get; set; }
    public string? RecipientType { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public int? RetailerCode { get; set; }
    public string? RetailerTitle { get; set; }
    public int RetailerAccessCount { get; set; }
    public string? TransactionId { get; set; }
    public List<int> RetailerAccess { get; set; } = new();
    public int UserCredentialId { get; set; }
    public List<IysErrorFull>? Errors { get; set; }
    public DateTime? IysCreationDate { get; set; }
    public DateTime? LastQueryDate { get; set; }
    public int? FirmId { get; set; }

    /// <summary>MongoDB NewFirms koleksiyonundaki ObjectId — SQL kaldırılınca birincil referans</summary>
    public string? FirmMongoId { get; set; }

    public int? NewCariKartId { get; set; }

    /// <summary>CariKart MongoDB referansı — SQL kapandığında kullanılır</summary>
    public string? NewCariKartMongoId { get; set; }

    public int? MssqlId { get; set; }

    /// <summary>UserAgreementLogs MongoDB referansı — SQL kapandığında kullanılır</summary>
    public string? UserAgreementMongoId { get; set; }

    public string? IdentityNumber { get; set; }

    [BsonExtraElements]
    public BsonDocument ExtraElements { get; set; }
}
