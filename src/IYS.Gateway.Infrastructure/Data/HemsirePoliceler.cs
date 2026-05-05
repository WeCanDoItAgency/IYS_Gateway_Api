using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class HemsirePoliceler
{
    public int Id { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public int SigortaId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsPolice { get; set; }

    public bool IsSuccess { get; set; }

    public string? WbStatus { get; set; }

    public string? WbDescription { get; set; }

    public string? PoliceNo { get; set; }

    public string? InputData { get; set; }

    public string? OutputData { get; set; }

    public string? QueryType { get; set; }

    public string? IncomingFile { get; set; }

    public string? OutgoingFile { get; set; }

    public bool IsPayment3d { get; set; }

    public string? IncomingFileSlip { get; set; }

    public string? OutgoingFileSlip { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public int? ComissionId { get; set; }

    public int? CommissionType { get; set; }

    public double? UsedKontor { get; set; }

    public double? CalculatedCommission { get; set; }

    public double? UsedKontorBranch { get; set; }

    public double? CalculatedCommissionBranch { get; set; }

    public int? BranchCommissionId { get; set; }

    public bool? IsUsedKontor { get; set; }

    public int? CalisilanBranchCommissionId { get; set; }

    public int? CalisilanUserCommissionId { get; set; }

    public double? CalisilanUserCalculatedCommission { get; set; }

    public double? CalisilanBranchCalculatedCommission { get; set; }

    public int FromPlaceId { get; set; }

    public int? CampaignId { get; set; }

    public string? CampaignName { get; set; }

    public int? CampaignRuleId { get; set; }

    public decimal? CampaignPrice { get; set; }

    public int? CampaignPriceTypeId { get; set; }

    public int ZeyilNo { get; set; }

    public int TecditNo { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsMongoSync { get; set; }

    public string? MongoId { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public bool? ReportErrorDetected { get; set; }

    public int? AskedCenterUserId { get; set; }

    public int? IslemSahibiUserId { get; set; }

    public int? IslemSahibiSktid { get; set; }

    public decimal? IslemSahibiSktcalculatedCommission { get; set; }

    public int? IslemSahibiSktcommissionType { get; set; }

    public int? IslemSahibiSktcommissionId { get; set; }

    public decimal? IslemSahibiUserCalculatedCommission { get; set; }

    public int? IslemSahibiUserCommissionType { get; set; }

    public int? IslemSahibiUserCommissionId { get; set; }

    public bool IslemSahibiDegistimi { get; set; }

    public bool? IsOpenCardPayment { get; set; }

    public string? ReferansCode { get; set; }

    public Guid PolicyGuid { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public int? RdpBrandPartajId { get; set; }

    public string? PartajNo { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public int? ResponseStatusCode { get; set; }

    public string? ResponseStatusCodeDescription { get; set; }

    public string? PaymentAgentCode { get; set; }

    public string? PaymentUserName { get; set; }

    public string? PaymentPassword { get; set; }

    public string? SigortaliAdi { get; set; }

    public string? NationalNumber { get; set; }

    public decimal? BrutPrim { get; set; }

    public decimal? NetPrim { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? UseOpenPayment { get; set; }

    public bool? UseSubbrandOpenPayment { get; set; }

    public string? UtmGclid { get; set; }

    public string? UtmGraid { get; set; }

    public string? UtmTargetid { get; set; }

    public string? UtmKeyword { get; set; }

    public string? UtmMatchtype { get; set; }

    public string? UtmDevice { get; set; }

    public string? UtmCreative { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public bool? BizdenMi { get; set; }

    public bool? SirketKartiMi { get; set; }

    public int? FirmCreditCardInfoId { get; set; }

    public int? ExtraCampaignId { get; set; }

    public string? ExtraCampaignName { get; set; }

    public int? ExtraCampaignRuleId { get; set; }

    public decimal? ExtraCampaignPrice { get; set; }

    public int? ExtraCampaignPriceTypeId { get; set; }

    public int? MarketerUserId { get; set; }

    public string? MarketerName { get; set; }

    public int? ReferanceCustomerUserId { get; set; }

    public int? ReferanceCustomerCodeId { get; set; }

    public string? ReferanceCustomerCode { get; set; }

    public string? ReferanceCustomerName { get; set; }

    public bool? TahsilatiVarMi { get; set; }

    public virtual Subeler Branch { get; set; } = null!;

    public virtual NewFirms? CalisilanfirmaNavigation { get; set; }

    public virtual Subeler? CalisilansubeNavigation { get; set; }

    public virtual Kullanicilar? CalisilanuserNavigation { get; set; }

    public virtual HemsireDetaylar Detay { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar Kuser { get; set; } = null!;
}
