using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// Çekiliş katılım kayıtları — MSSQL RaffleEntries entity'sinin MongoDB karşılığı.
/// FK: RaffleId → Raffle (LOCAL), HeaderId/DetailId/PaymentId + Querytype → MONGO_53 (COMPOSITE).
/// </summary>
[BsonCollection("RaffleEntries")]
[BsonIgnoreExtraElements]
public class RaffleEntriesMongo : MongoDbEntity
{
    /// <summary>SQL PK — sync engine tarafından otomatik rename edilir.</summary>
    public int MssqlId { get; set; }

    public string Phone { get; set; } = null!;

    public string IdentityNumber { get; set; } = null!;

    public int Entries { get; set; }

    public DateTime CreateDate { get; set; }

    public int Type { get; set; }

    public int? PaymentId { get; set; }

    public int? DetailId { get; set; }

    public int? HeaderId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int RaffleId { get; set; }

    public string Querytype { get; set; } = null!;

    /// <summary>LOCAL FK → Raffle (Phase 1b INLINE)</summary>
    public ObjectId? RaffleMongoId { get; set; }

    /// <summary>COMPOSITE FK → HeadersMongo (Phase 2.5, MONGO_53/Offers)</summary>
    public ObjectId? HeaderMongoId { get; set; }

    /// <summary>COMPOSITE FK → OffersMongo (Phase 2.5, MONGO_53/Offers)</summary>
    public ObjectId? DetailMongoId { get; set; }

    /// <summary>COMPOSITE FK → PoliciesMongo (Phase 2.5, MONGO_53/Offers)</summary>
    public ObjectId? PaymentMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
