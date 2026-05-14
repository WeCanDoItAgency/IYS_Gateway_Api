using System;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("MusteriAraclariUserMapping")]
[BsonIgnoreExtraElements]
public class MusteriAraclariUserMappingMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public Guid MusteriAraclariGuid { get; set; }
    public string? MusteriAraclariGuidStr { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? MusteriAraclariMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
