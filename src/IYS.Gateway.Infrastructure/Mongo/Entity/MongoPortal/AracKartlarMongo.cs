using System;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("AracKartlar")]
[BsonIgnoreExtraElements]
public class AracKartlarMongo : MongoDbEntity
{
    public long MssqlId { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public string? Plaka { get; set; }

    public string? RuhsatNo { get; set; }

    public string? AsbisNo { get; set; }

    public string? MarkaKodu { get; set; }

    public int? ModelYili { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public DateTime? TrafikCikisTarihi { get; set; }

    public DateTime? TrafikTescilTarihi { get; set; }

    public string? AracTarzKodu { get; set; }

    public string? TarifeKodu { get; set; }

    public string? KullanimSekliKodu { get; set; }

    public int? YakitTipi { get; set; }

    public int? GarajTipi { get; set; }

    public string? RenkKodu { get; set; }

    public string? KoltukSayisi { get; set; }

    public int? MarkaId { get; set; }

    public string? ModelKodu { get; set; }

    public decimal? AracBedeli { get; set; }

    public double? Radyoteyp { get; set; }

    public double? Navigasyon { get; set; }

    public double? Celikjant { get; set; }

    public double? Televizyon { get; set; }

    public double? Digeraksesuar { get; set; }

    public int? AracAltTip { get; set; }

    public bool? IsYk { get; set; }

    public bool? IsAksesuar { get; set; }

    public double? Lpg { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDisabled { get; set; }

    public int? CascoVehicleType { get; set; }

    public int? TrafficVehicleType { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? FirmMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? SubeMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? MarkaMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UpdatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? DeletedUserMongoId { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
