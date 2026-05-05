using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NakliyatBaslik
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string MusteriVknNo { get; set; } = null!;

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string? MobilePhone { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? TransferTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public bool IsPolice { get; set; }

    public int? SigortaId { get; set; }

    public string? PoliceNo { get; set; }

    public bool IsCancel { get; set; }

    public string? QueryType { get; set; }

    public string? Email { get; set; }

    public string? AracPlaka { get; set; }

    public int? Gemi { get; set; }

    public int? GemiBayrak { get; set; }

    public int? IslemTipi { get; set; }

    public int? IslemTuru { get; set; }

    public string? DovizCinsi { get; set; }

    public string? PoliceTuru { get; set; }

    public string? AracTipi { get; set; }

    public int? TeminatKodu { get; set; }

    public int? TurkLimanKodu { get; set; }

    public int? BaslangicPort { get; set; }

    public int? HedefPort { get; set; }

    public double? Miktar { get; set; }

    public int? EmtiaKodu { get; set; }

    public int? AmbalajKodu { get; set; }

    public int TeminatBedeli { get; set; }

    public string? SigortaettirenVknNo { get; set; }

    public string? SigortaettirenAdi { get; set; }

    public string? SigortaettirenSoyadi { get; set; }

    public string? EmtiaName { get; set; }

    public string? EncryptedId { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? ExpertiseRequestId { get; set; }

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

    public int? MeslekKodu { get; set; }

    public bool? IsAutoVisitorProcess { get; set; }

    public double? AutoVisitorProcessRate { get; set; }

    public DateTime? SendAutoWorkQueueDate { get; set; }

    public DateTime? ResponseAutoWorkQueueDate { get; set; }

    public bool? ZeyilGordu { get; set; }

    public bool? IsScheduled { get; set; }

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

    public string? Cinsiyet { get; set; }

    public string? UtmTerm { get; set; }

    public string? GadSource { get; set; }

    public bool? OncekiBizdenMi { get; set; }

    public bool? RakipMusteriMi { get; set; }

    public string? RakipMusteriAdi { get; set; }

    public string? Device { get; set; }

    public string? PlayerId { get; set; }

    public string? DeviceModel { get; set; }

    public string? BuildNumber { get; set; }

    public virtual Subeler Branch { get; set; } = null!;

    public virtual NewFirms? CalisilanfirmaNavigation { get; set; }

    public virtual Subeler? CalisilansubeNavigation { get; set; }

    public virtual Kullanicilar? CalisilanuserNavigation { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar Kuser { get; set; } = null!;

    public virtual ICollection<NakliyatDetay> NakliyatDetay { get; set; } = new List<NakliyatDetay>();
}
