using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class KonutBasliklar
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsRenewal { get; set; }

    public string? EskiPoliceNo { get; set; }

    public string MusteriVknNo { get; set; } = null!;

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public DateTime TanzimTarihi { get; set; }

    public string? TelefonNo { get; set; }

    public string? Email { get; set; }

    public string? UavtKodu { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? IlKodu { get; set; }

    public string? IlceKodu { get; set; }

    public string? BeldeKodu { get; set; }

    public string? MahalleKodu { get; set; }

    public string? SokakKodu { get; set; }

    public string? BinaNo { get; set; }

    public string? DaireNo { get; set; }

    public string? TeminatBina { get; set; }

    public string? TeminatEsya { get; set; }

    public string? TeminatCam { get; set; }

    public string? TeminatDekorasyon { get; set; }

    public int? BrutYuzOlcum { get; set; }

    public int? InsaaTarzi { get; set; }

    public int? KullanimSekli { get; set; }

    public int? ToplamKat { get; set; }

    public int? InsaaYili { get; set; }

    public int? BulunduguKat { get; set; }

    public bool IsPolice { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? PoliceNo { get; set; }

    public int? SigortaId { get; set; }

    public string? EncryptedId { get; set; }

    public bool? Daskvarmi { get; set; }

    public string? DaskPoliceNo { get; set; }

    public bool? BosKalma { get; set; }

    public int? CatiTipi { get; set; }

    public string? DainiMurtein { get; set; }

    public string? BankaKodu { get; set; }

    public string? BsubeKodu { get; set; }

    public string? FinansKurumu { get; set; }

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

    public bool? IsEarthquakeInsurance { get; set; }

    public string? InflationValue { get; set; }

    public string? MachineryBreakageGuarantee { get; set; }

    public string? ElectronicDeviceGuarantee { get; set; }

    public string? FireLiabilityGuarantee { get; set; }

    public string? HouseType { get; set; }

    public bool? IsTenant { get; set; }

    public string? PolicyType { get; set; }

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

    public virtual ICollection<KonutDetaylar> KonutDetaylar { get; set; } = new List<KonutDetaylar>();

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
