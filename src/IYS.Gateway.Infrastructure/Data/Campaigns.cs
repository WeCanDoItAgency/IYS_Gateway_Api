using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Campaigns
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public string? CampaignName { get; set; }

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public int? CampaignType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? RefundTypeId { get; set; }

    public bool? IsSendCurrentSms { get; set; }

    public bool? IsSendCurrentEmail { get; set; }

    public bool? IsHaveLimit { get; set; }

    public int? TopLimit { get; set; }

    public int? SubLimit { get; set; }

    public string? CampaignBanner { get; set; }

    public string? SupplierName { get; set; }

    public string? SupplierLogo { get; set; }

    public bool? IsRequireTopSub { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? DiscountType { get; set; }

    public decimal? Discount { get; set; }

    public int? AfterDayControl { get; set; }

    public bool IsSecret { get; set; }

    public string? SmsUsageText { get; set; }

    public string? SmsSupplierName { get; set; }

    public bool IsVisibleForSite { get; set; }

    public bool? IsVisibleForMobile { get; set; }

    public bool? IsFlashCampain { get; set; }

    public DateTime? FlashCampainStartDate { get; set; }

    public DateTime? FlashCampainEndDate { get; set; }

    public string? FlashCampainTag1 { get; set; }

    public string? FlashCampainTag2 { get; set; }

    public string? FlashCampainTag3 { get; set; }

    public string? FlashCampainTag4 { get; set; }

    public bool? JustMobileCampain { get; set; }

    public int? ReferanceCustomerHakedis { get; set; }

    public bool? ReferanceCustomerCodeUsableWithOtherCampaign { get; set; }

    public string? UrlSpecialCode { get; set; }

    public string? UrlPhotoPath { get; set; }

    public int? UrlPhotoDisplayType { get; set; }

    public string? UrlPhotoPath1200 { get; set; }

    public string? UrlPhotoPath432 { get; set; }

    public bool? IsThereCountDown { get; set; }

    public virtual ICollection<AcenteOnlineCmsblogPosts> AcenteOnlineCmsblogPosts { get; set; } = new List<AcenteOnlineCmsblogPosts>();

    public virtual ICollection<CampaignCodeRules> CampaignCodeRules { get; set; } = new List<CampaignCodeRules>();

    public virtual ICollection<CampaignCodes> CampaignCodes { get; set; } = new List<CampaignCodes>();

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<CampaignMessages> CampaignMessages { get; set; } = new List<CampaignMessages>();

    public virtual ICollection<CampaignQueryTypeMapping> CampaignQueryTypeMapping { get; set; } = new List<CampaignQueryTypeMapping>();

    public virtual ICollection<CampaignTypeMapping> CampaignTypeMapping { get; set; } = new List<CampaignTypeMapping>();

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<ReferenceCustomerEntitledUserMapping> ReferenceCustomerEntitledUserMapping { get; set; } = new List<ReferenceCustomerEntitledUserMapping>();

    public virtual CampaignRefundTypes? RefundType { get; set; }
}
