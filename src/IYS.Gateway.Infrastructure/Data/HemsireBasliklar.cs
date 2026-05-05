using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class HemsireBasliklar
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

    public int? MeslekKodu { get; set; }

    public int? CalismaBolumu { get; set; }

    public int? TeminatLimiti { get; set; }

    public bool? TazminatTalebi { get; set; }

    public bool? IsSorumluluk { get; set; }

    public bool IsPolice { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? PoliceNo { get; set; }

    public int? SigortaId { get; set; }

    public string? EncryptedId { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public bool? IsCrossSellingOffer { get; set; }

    public string? CrossSellingOfferGuid { get; set; }

    public int? FromPlaceId { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? BusinessRuleId { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public string? MongoId { get; set; }

    public string? Visitor { get; set; }

    public Guid HeaderGuid { get; set; }

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

    public virtual ICollection<HemsireDetaylar> HemsireDetaylar { get; set; } = new List<HemsireDetaylar>();

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
