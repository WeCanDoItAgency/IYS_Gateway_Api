using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// Çekiliş kampanya tanımları tablosu — MSSQL Raffle entity'sinin MongoDB karşılığı.
/// </summary>
[BsonCollection("Raffle")]
[BsonIgnoreExtraElements]
public class RaffleMongo : MongoDbEntity
{
    /// <summary>SQL PK — sync engine tarafından otomatik rename edilir.</summary>
    public int MssqlId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Banner { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? EndDate { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
