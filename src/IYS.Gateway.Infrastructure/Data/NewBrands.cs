using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewBrands
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    public string? Url { get; set; }

    public int? DisplayOrder { get; set; }

    public string? ApiName { get; set; }

    public string? TimeOutSecond { get; set; }

    public string? AccountingCode { get; set; }

    public bool? AutomobileInsurance { get; set; }

    public bool? ForeignInsurance { get; set; }

    public bool? TrafficInsurance { get; set; }

    public bool? DaskInsurance { get; set; }

    public bool? AdditiveHealthInsurance { get; set; }

    public bool? IncomingInsurance { get; set; }

    public bool? OutgoingInsurance { get; set; }

    public bool? TransportInsurance { get; set; }

    public bool? SecondHandInsurance { get; set; }

    public bool? PersonalHealthInsurance { get; set; }

    public bool? PersonalAccidentInsurance { get; set; }

    public bool? HouseInsurance { get; set; }

    public bool? NurseInsurance { get; set; }

    public bool? PetInsurance { get; set; }

    public bool? MobilePhoneInsurance { get; set; }

    public bool? WeddingInsurance { get; set; }

    public string? ShortCode { get; set; }

    public double? StaticCommissionAmount { get; set; }

    public bool? IsSendInstallementValue { get; set; }

    public int? UserId { get; set; }

    public bool? IsRunforEgm { get; set; }

    public bool IsRunForKpsSystem { get; set; }

    public bool? IsTssFamily { get; set; }

    public bool? IsTssUnder18Child { get; set; }

    public int? IsTssMinAge { get; set; }

    public bool? IsOutgForEducationPurpose { get; set; }

    public bool? IsOutgForWorkPurpose { get; set; }

    public bool IsRunForBot { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public bool? IsActive { get; set; }

    public string? Smsregex { get; set; }

    public string? SmsfromTitle { get; set; }

    public bool? OtoKazaAnlasmali { get; set; }

    public bool? SaglikAnlasmali { get; set; }

    public string? OtoKazaAnlasmaliUrl { get; set; }

    public string? SaglikAnlasmaliUrl { get; set; }

    public string? ReCaptchaCode { get; set; }

    public string? PolicyInformationFilePath { get; set; }

    public string? PolicyInformationFileName { get; set; }

    public bool? ScreenOpeningLimits { get; set; }

    public TimeOnly? ScreenOpenTime { get; set; }

    public TimeOnly? ScreenCloseTime { get; set; }

    public bool? ImmInsurance { get; set; }

    public bool? FerdiKazaInsurance { get; set; }

    public bool? OdemedeKendiFormunuKullansinMi { get; set; }

    public bool? KaskoYkCalissinMi { get; set; }

    public bool? TrafikYkCalissinMi { get; set; }

    public string? IconUrl { get; set; }

    public bool? IptalZeyillerOtomatikSistemeGonderilsinMi { get; set; }

    public bool? KisaTrafikInsurance { get; set; }

    public bool? YesilkartInsurance { get; set; }

    public int? KaskoAracCalismaYasSiniri { get; set; }

    public int? KaskoAracCalismaYeniTescilYasSiniri { get; set; }

    public int? TssMusteriYasSiniri { get; set; }

    public bool? GalericiKisaTrafikInsurance { get; set; }

    public bool? HukuksalKorumaInsurance { get; set; }

    public bool? GalericiFerdiKazaInsurance { get; set; }

    public bool? GalericiSeyahatInsurance { get; set; }

    public bool? EvAletimGuvendeInsurance { get; set; }

    public bool? BesInsurance { get; set; }

    public bool? HayatInsurance { get; set; }

    public bool? ZorunluKoltukInsurance { get; set; }

    public bool? IsSfs { get; set; }

    public bool? ZeyilIptalEvrakGerekliMi { get; set; }

    public bool? EvraksizZeyilCalisabilirMi { get; set; }

    public Guid Guid { get; set; }

    public virtual ICollection<AdditionalPremiumDiscount> AdditionalPremiumDiscount { get; set; } = new List<AdditionalPremiumDiscount>();

    public virtual ICollection<BrandApiAddress> BrandApiAddress { get; set; } = new List<BrandApiAddress>();

    public virtual ICollection<BrandAttributeGroup> BrandAttributeGroup { get; set; } = new List<BrandAttributeGroup>();

    public virtual ICollection<BrandQueryTypeRdpBrowserAuth> BrandQueryTypeRdpBrowserAuth { get; set; } = new List<BrandQueryTypeRdpBrowserAuth>();

    public virtual ICollection<BrandQuerytypeBotAuth> BrandQuerytypeBotAuth { get; set; } = new List<BrandQuerytypeBotAuth>();

    public virtual ICollection<NewBrandDocuments> NewBrandDocuments { get; set; } = new List<NewBrandDocuments>();

    public virtual ICollection<NewRdpBrandPartajs> NewRdpBrandPartajs { get; set; } = new List<NewRdpBrandPartajs>();

    public virtual ICollection<NewSubBrands> NewSubBrands { get; set; } = new List<NewSubBrands>();

    public virtual ICollection<PartajDefinitions> PartajDefinitions { get; set; } = new List<PartajDefinitions>();

    public virtual ICollection<RdpBrandPartajs> RdpBrandPartajs { get; set; } = new List<RdpBrandPartajs>();
}
