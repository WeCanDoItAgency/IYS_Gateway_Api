using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("AracModelKodlariAractipiMap")]
[BsonIgnoreExtraElements]
public class AracModelKodlariAractipiMapMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public int BrandId { get; set; }

    public string? BrandCode { get; set; }

    public string? ModelCode { get; set; }

    public int VehicleType { get; set; }

    public string? QueryType { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BrandMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
