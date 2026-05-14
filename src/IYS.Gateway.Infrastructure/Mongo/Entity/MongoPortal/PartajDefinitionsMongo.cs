using System;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("PartajDefinitions")]
[BsonIgnoreExtraElements]
public class PartajDefinitionsMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public string? AgencyName { get; set; }

    public int BrandId { get; set; }

    public string? PartajCode { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BrandMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UpdatedUserMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
