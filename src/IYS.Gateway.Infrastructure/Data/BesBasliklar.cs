using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BesBasliklar
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public bool IsPolice { get; set; }

    public bool IsCancel { get; set; }

    public string? PoliceNo { get; set; }

    public DateTime CreateDate { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string? MobilPhone { get; set; }

    public string MusteriVknNo { get; set; } = null!;

    public bool IsPoliceStatus { get; set; }

    public int? SigortaId { get; set; }

    public string? Email { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public int StatusId { get; set; }

    public int? MeslekKodu { get; set; }

    public string? EncryptedId { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public bool? IsDisabled { get; set; }

    public bool? IsRenew { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public bool? IsCrossSellingOffer { get; set; }

    public string? CrossSellingOfferGuid { get; set; }

    public bool? IsFromRenewal { get; set; }

    public bool? IsFromNewUnbought { get; set; }

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

    public bool? ZeyilGordu { get; set; }

    public bool IsScheduled { get; set; }

    public bool? RevizeliTeklifiVar { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public bool? TeklifDurumaGonderildi { get; set; }

    public string? CrossSellingStartQueryType { get; set; }

    public string? UtmGclid { get; set; }

    public string? UtmGraid { get; set; }

    public string? UtmKeyword { get; set; }

    public string? UtmMatchtype { get; set; }

    public string? UtmDevice { get; set; }

    public string? UtmCreative { get; set; }

    public string? UtmTargetid { get; set; }

    public bool? OncekiBizdenMi { get; set; }

    public string? UtmTerm { get; set; }

    public string? GadSource { get; set; }

    public int? KatkiPayi { get; set; }

    public int? KatkiPeriod { get; set; }

    public string? Cinsiyet { get; set; }

    public bool? RakipMusteriMi { get; set; }

    public string? RakipMusteriAdi { get; set; }

    public virtual ICollection<BesPoliceler> BesPoliceler { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BesTeklifler> BesTeklifler { get; set; } = new List<BesTeklifler>();

    public virtual Subeler Branch { get; set; } = null!;

    public virtual NewFirms? CalisilanfirmaNavigation { get; set; }

    public virtual Subeler? CalisilansubeNavigation { get; set; }

    public virtual Kullanicilar? CalisilanuserNavigation { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
