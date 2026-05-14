using System;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("AracMarkaKodlari")]
[BsonIgnoreExtraElements]
public class AracMarkaKodlariMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public string? MarkaKodu { get; set; }

    public string? MarkaAdi { get; set; }

    public string? Logo { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UpdatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? DeletedUserMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
