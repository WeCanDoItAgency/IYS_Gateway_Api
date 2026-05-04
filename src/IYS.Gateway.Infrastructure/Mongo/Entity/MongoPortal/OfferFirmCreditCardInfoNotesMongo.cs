using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("OfferFirmCreditCardInfoNotes")]
[BsonIgnoreExtraElements]
public class OfferFirmCreditCardInfoNotesMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public string? HeaderGuidStr { get; set; }

    public Guid? DetailGuid { get; set; }

    public string? DetailGuidStr { get; set; }

    public Guid? PolicyGuid { get; set; }

    public string? PolicyGuidStr { get; set; }

    public string? CenterWaitingMongoId { get; set; }

    public int? FirmCreditCardInfoId { get; set; }

    public string? Note { get; set; }

    public int? FirmId { get; set; }

    public int? ManuelOperationsId { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? FirmMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? FirmCreditCardInfoMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ManuelOperationsMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument ExtraElements { get; set; }
}
