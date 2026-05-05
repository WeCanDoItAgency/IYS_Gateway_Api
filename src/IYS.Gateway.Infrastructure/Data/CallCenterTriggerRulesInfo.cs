using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterTriggerRulesInfo
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string? RuleName { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual ICollection<CallCenterTriggerRules> CallCenterTriggerRules { get; set; } = new List<CallCenterTriggerRules>();

    public virtual ICollection<CallCenterTriggerRulesInfoSktMapping> CallCenterTriggerRulesInfoSktMapping { get; set; } = new List<CallCenterTriggerRulesInfoSktMapping>();

    public virtual NewFirms Firm { get; set; } = null!;
}
