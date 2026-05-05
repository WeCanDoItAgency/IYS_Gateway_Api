using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CommonHeader
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public bool IsPolice { get; set; }

    public string? PoliceNo { get; set; }

    public DateTime CreateDate { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string? MobilPhone { get; set; }

    public string? UretimBrans { get; set; }

    public string? UretimBransAdi { get; set; }

    public string? AracPlaka { get; set; }

    public string? AracRuhsatNo { get; set; }

    public string? MusteriVknNo { get; set; }

    public string? PasaportNo { get; set; }

    public string? YbKimlikNo { get; set; }

    public string? Adres { get; set; }

    public string? UavtKodu { get; set; }

    public string? AracMotorNo { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public int? SigortaId { get; set; }

    public string? QueryType { get; set; }

    public string? Email { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? EncryptedId { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public bool? ZeyilGordu { get; set; }

    public int? FromPlaceId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public string? MongoId { get; set; }

    public Guid HeaderGuid { get; set; }

    public bool IsScheduled { get; set; }

    public string? AcenteNo { get; set; }

    public string? SirketNo { get; set; }

    public string? YenilemeNo { get; set; }

    public string? ZeyilNo { get; set; }

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

    public string? CrossSellingOfferGuid { get; set; }

    public string? CrossSellingStartQueryType { get; set; }

    public bool? IsCrossSellingOffer { get; set; }

    public int? AnaSigortaHukuksalKorumaDegeri { get; set; }

    public int? BereketSigortaFerdiKazaDegeri { get; set; }

    public bool? IsAutoVisitorProcess { get; set; }

    public DateTime? SendAutoWorkQueueDate { get; set; }

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

    public virtual ICollection<CommonDetail> CommonDetail { get; set; } = new List<CommonDetail>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
