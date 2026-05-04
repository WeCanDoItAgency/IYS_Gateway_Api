using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("CarQueryRequest")]
[BsonIgnoreExtraElements]
public class CarQueryRequestMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public int QuerytypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int Status { get; set; }

    public int FirmId { get; set; }

    public bool IsPolice { get; set; }

    public bool? PolicesiBitmisOlanlarDahilEdilsinMi { get; set; }

    public bool? IsAutoRequest { get; set; }

    public string? FilePath { get; set; }

    public string? ErrorMessage { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? FirmMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? QuerytypeMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument ExtraElements { get; set; }
}
