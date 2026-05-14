using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("EmailProfessionNationalGsmRelations")]
[BsonIgnoreExtraElements]
public class EmailProfessionNationalGsmRelationsMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public string? NationalNumber { get; set; }

    public string? Gsm { get; set; }

    public string? Email { get; set; }

    public string? TrafficProfessionCode { get; set; }

    public string? AdditiveProfessionCode { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
