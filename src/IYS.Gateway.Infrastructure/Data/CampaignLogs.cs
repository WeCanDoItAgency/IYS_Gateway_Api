using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignLogs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public int? BranchId { get; set; }

    public int CampaignId { get; set; }

    public int? ExistRuleId { get; set; }

    public int? RuleId { get; set; }

    public int QueryTypeId { get; set; }

    public int HeaderId { get; set; }

    public int? DetailId { get; set; }

    public int? PaymentId { get; set; }

    public bool IsPolicy { get; set; }

    public DateTime? UseDate { get; set; }

    public DateTime? AppliedDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsFraud { get; set; }

    public string? IdentityNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerSurname { get; set; }

    public decimal? NetPrim { get; set; }

    public decimal? BrutPrim { get; set; }

    public decimal? Hakedis { get; set; }

    public bool IsApproved { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? ApprovedMessage { get; set; }

    public int? CodeSharedBy { get; set; }

    public DateTime? CodeSharedDate { get; set; }

    public decimal? CustomDiscount { get; set; }

    public bool MtLog { get; set; }

    public bool IsMtRequestApprove { get; set; }

    public int? MtRequestApprovedBy { get; set; }

    public DateTime? MtRequestApprovedDate { get; set; }

    public string? MtRequestApproveMessage { get; set; }

    public int? SigortaId { get; set; }

    public int? CodeId { get; set; }

    public bool? IsNotApproved { get; set; }

    public string? NotApprovedReason { get; set; }

    public int? NotApprovedBy { get; set; }

    public DateTime? NotApprovedDate { get; set; }

    public string? ReferansCode { get; set; }

    public string? PolicyNo { get; set; }

    public bool? IsApprovedManuel { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public Guid? PaymentGuid { get; set; }

    public virtual Kullanicilar? ApprovedByNavigation { get; set; }

    public virtual Subeler? Branch { get; set; }

    public virtual Campaigns Campaign { get; set; } = null!;

    public virtual CampaignCodeRules? ExistRule { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual NewQueryTypes QueryType { get; set; } = null!;

    public virtual NewSubBrands? Sigorta { get; set; }

    public virtual Kullanicilar? User { get; set; }
}
