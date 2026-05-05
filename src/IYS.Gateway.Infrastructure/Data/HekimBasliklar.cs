using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class HekimBasliklar
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string MusteriVknNo { get; set; } = null!;

    public DateTime TanzimTarihi { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? TelefonNo { get; set; }

    public string? Email { get; set; }

    public int? TescilTuru { get; set; }

    public int? TescilNo { get; set; }

    public string? TescilTarihi { get; set; }

    public int? UzmanlikAlani { get; set; }

    public int? UzmanlikKodu { get; set; }

    public int? Isasistan { get; set; }

    public int? TramerBasamak { get; set; }

    public string? CalistigiKurum { get; set; }

    public string? CalismaAdresi { get; set; }

    public string? SeVknNo { get; set; }

    public string? SeTelefon { get; set; }

    public string? SeAdi { get; set; }

    public string? SeSoyadi { get; set; }

    public string? SeAdres { get; set; }

    public int? Odemesekli { get; set; }

    public bool? TazminatTalebi { get; set; }

    public bool? IsSorumluluk { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? PoliceNo { get; set; }

    public int? SigortaId { get; set; }

    public string? EncryptedId { get; set; }

    public double? NetPrim { get; set; }

    public double? Vergi { get; set; }

    public double? BrutPrim { get; set; }

    public DateTime? Birthdate { get; set; }

    public bool? IsCrossSellingOffer { get; set; }

    public string? CrossSellingOfferGuid { get; set; }

    public int? FromPlaceId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? BusinessRuleId { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public string? MongoId { get; set; }

    public Guid HeaderGuid { get; set; }

    public string? Visitor { get; set; }

    public bool? ZeyilGordu { get; set; }

    public bool IsScheduled { get; set; }

    public bool? RevizeliTeklifiVar { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public string? UtmGclid { get; set; }

    public string? UtmGraid { get; set; }

    public string? UtmTargetid { get; set; }

    public string? UtmKeyword { get; set; }

    public string? UtmMatchtype { get; set; }

    public string? UtmDevice { get; set; }

    public string? UtmCreative { get; set; }

    public string? Device { get; set; }

    public string? PlayerId { get; set; }

    public string? DeviceModel { get; set; }

    public string? BuildNumber { get; set; }
}
