using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FerdikazateklifBasliklar
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string? MobilPhone { get; set; }

    public string AracPlaka { get; set; } = null!;

    public string? AracRuhsatNo { get; set; }

    public string? AsbisNo { get; set; }

    public string? MusteriVknNo { get; set; }

    public string? PasaportNo { get; set; }

    public string? AracMarkaKodu { get; set; }

    public int? ModelYili { get; set; }

    public int? MarkaId { get; set; }

    public string? ModelKodu { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public int? SigortaId { get; set; }

    public string? PoliceNo { get; set; }

    public bool IsPolice { get; set; }

    public int? Menfaattar { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public string? KoyKodu { get; set; }

    public string? MahalleKodu { get; set; }

    public string? CsbmKodu { get; set; }

    public string? BinaNo { get; set; }

    public string? PostaKodu { get; set; }

    public string? SigortaettirenVknNo { get; set; }

    public string? Email { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public string? EncryptedId { get; set; }

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

    public bool IsScheduled { get; set; }

    public bool? RevizeliTeklifiVar { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public string? TaksitSayisi { get; set; }

    public DateTime? OncekiBaslangic { get; set; }

    public DateTime? OncekiBitis { get; set; }

    public string? OncekiSirketKodu { get; set; }

    public string? OncekiAcenteNo { get; set; }

    public string? OncekiPoliceNo { get; set; }

    public string? OncekiYenilemeNo { get; set; }

    public DateTime? TrafikCikisTarihi { get; set; }

    public DateTime? TrafikTescilTarihi { get; set; }

    public bool? IsOriginalLpg { get; set; }

    public bool? IsFromRenewal { get; set; }

    public bool? IsFromNewUnbought { get; set; }

    public int? HasarSayisi { get; set; }

    public int? HasarsizlikKademesi { get; set; }

    public double? SilindirHacmi { get; set; }

    public bool? IsRenew { get; set; }

    public bool? IsRenewalPeriodTraffic { get; set; }

    public bool? IsClickContinueTraffic { get; set; }

    public string DainiMDurum { get; set; } = null!;

    public string? BankaKodu { get; set; }

    public string? BsubeKodu { get; set; }

    public string? FinansKurumu { get; set; }

    public bool IsLocked { get; set; }

    public bool IsReady { get; set; }

    public int StatusId { get; set; }

    public bool IsCancel { get; set; }

    public double? Radyoteyp { get; set; }

    public double? Navigasyon { get; set; }

    public double? Celikjant { get; set; }

    public double? Televizyon { get; set; }

    public double? Lpg { get; set; }

    public double? Digeraksesuar { get; set; }

    public string? DigerAksesuarAciklama { get; set; }

    public bool? IsAksesuar { get; set; }

    public bool IsPoliceStatus { get; set; }

    public bool? IsYk { get; set; }

    public string? CrossSellingStartQueryType { get; set; }

    public string? AracMotorNo { get; set; }

    public string? AracSasiNo { get; set; }

    public int? AracTarzKodu { get; set; }

    public int? AracTarifeKodu { get; set; }

    public int? AracKsekliKodu { get; set; }

    public int? YakitTipi { get; set; }

    public int? GarajTipi { get; set; }

    public int? RenkKodu { get; set; }

    public string? KoltukSayisi { get; set; }

    public string? QueryType { get; set; }

    public string? BeldeKodu { get; set; }

    public int? DaskBeldeId { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Cinsiyet { get; set; }

    public double? AracBedeli { get; set; }

    public bool? IsDisabled { get; set; }

    public string? UtmGclid { get; set; }

    public string? UtmGraid { get; set; }

    public string? UtmTargetid { get; set; }

    public string? UtmKeyword { get; set; }

    public string? UtmMatchtype { get; set; }

    public string? UtmDevice { get; set; }

    public string? UtmCreative { get; set; }

    public string? UtmTerm { get; set; }

    public string? GadSource { get; set; }

    public bool? OncekiBizdenMi { get; set; }

    public int? AnaSigortaHukuksalKorumaDegeri { get; set; }

    public int? BereketSigortaFerdiKazaDegeri { get; set; }

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

    public virtual ICollection<FerdikazateklifDetay> FerdikazateklifDetay { get; set; } = new List<FerdikazateklifDetay>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
