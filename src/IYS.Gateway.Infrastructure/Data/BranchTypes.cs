using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchTypes
{
    public int Id { get; set; }

    public int? AccountancyPlanningId { get; set; }

    public int? GroupId { get; set; }

    public int? FirmId { get; set; }

    public int? Code { get; set; }

    public string? Name { get; set; }

    public bool? IsReferance { get; set; }

    public int? ReferanceId { get; set; }

    public bool? CanEnterAcente { get; set; }

    public bool? CanOpenSubBranch { get; set; }

    public bool? IsApprovalRequired { get; set; }

    public bool? IsOpenCariCard { get; set; }

    public bool? IsUseKontor { get; set; }

    public bool? IsShareKontor { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsRequiredCommissionConfirm { get; set; }

    public int? Priority { get; set; }

    public int? ApprovalUserId { get; set; }

    public bool? IsRequiredEvaluation1 { get; set; }

    public int? Evaluation1UserId { get; set; }

    public bool? IsRequiredEvaluation2 { get; set; }

    public int? Evaluation2UserId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewAccountancyPlannings? AccountancyPlanning { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<QueryRules> QueryRules { get; set; } = new List<QueryRules>();

    public virtual ICollection<Subeler> Subeler { get; set; } = new List<Subeler>();

    public virtual ICollection<WebNotifications> WebNotifications { get; set; } = new List<WebNotifications>();
}
