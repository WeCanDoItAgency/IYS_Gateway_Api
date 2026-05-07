using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
namespace IYS.Gateway.Infrastructure.Mongo.Entity.IYS;

/// <summary>
/// BusinessRulesLog tablosunun MongoDB kopyası (MONGO_206 / MongoPortal DB).
/// Karaliste/beyazliste işlemleri her zaman bu koleksiyona yazılır.
/// UseSqlDb=true ise ek olarak SQL'e de yazılır.
/// </summary>
[BsonCollection("BusinessRulesLog")]
[BsonIgnoreExtraElements]
public class BusinessRulesLogMongo : MongoDbEntity
{
    public int MssqlId { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int? BusinessRuleId { get; set; }
    public int? FirmId { get; set; }
    public bool? IsActive { get; set; }
    public int? CreatedUserId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }

}
