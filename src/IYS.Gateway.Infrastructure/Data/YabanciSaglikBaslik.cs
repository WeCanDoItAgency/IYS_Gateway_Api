using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class YabanciSaglikBaslik
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 1-pasaport 2-yabanci kimlik
    /// </summary>
    public int? IslemTipi { get; set; }

    public string? PasaportNo { get; set; }

    public string? YbKimlikNo { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? BabaAdi { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? DogumYeri { get; set; }

    public string? Cinsiyet { get; set; }

    public string? AlanKodu { get; set; }

    public string? Telefon { get; set; }

    public string? UlkeKodu { get; set; }

    public bool? IsYenileme { get; set; }

    public DateTime? YenilemeTarihi { get; set; }

    public int? Boy { get; set; }

    public int? Kilo { get; set; }

    public string? IlAdi { get; set; }

    public string? IlceAdi { get; set; }

    public string? Semt { get; set; }

    public string? Mahalle { get; set; }

    public string? Cadde { get; set; }

    public string? KapiNo { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public bool IsPolice { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public string? AnneAdi { get; set; }

    public string? PostaKodu { get; set; }

    public string? BinaNo { get; set; }

    public string? DaireNo { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public int? SigortaId { get; set; }

    public string? PoliceNo { get; set; }

    public string? Email { get; set; }

    public string? EncryptedId { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? SeAdi { get; set; }

    public string? SeSoyadi { get; set; }

    public DateTime? SeDogumtarihi { get; set; }

    public string? SeCinsiyet { get; set; }

    public string? SeUlkekodu { get; set; }

    public string? SeDogumyeri { get; set; }

    public bool? IsTwoYear { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

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

    public bool? IsAutoVisitorProcess { get; set; }

    public double? AutoVisitorProcessRate { get; set; }

    public DateTime? SendAutoWorkQueueDate { get; set; }

    public DateTime? ResponseAutoWorkQueueDate { get; set; }

    public int? MeslekKodu { get; set; }

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

    public virtual ICollection<YabanciSaglikDetay> YabanciSaglikDetay { get; set; } = new List<YabanciSaglikDetay>();
}
