using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterTriggerRules
{
    public int Id { get; set; }

    public int CallCenterTriggerRulesInfoId { get; set; }

    public int FirmId { get; set; }

    public int QueryType { get; set; }

    public int DaysNumber { get; set; }

    public int? Fromplace { get; set; }

    public int? CustomerType { get; set; }

    public int? Scope { get; set; }

    public int? RulesType { get; set; }

    public int? InsuredRuleType { get; set; }

    public int? ProductType { get; set; }

    public int? Amount { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? Minute { get; set; }

    public virtual ICollection<CallCenterTriggerRulesActions> CallCenterTriggerRulesActions { get; set; } = new List<CallCenterTriggerRulesActions>();

    public virtual CallCenterTriggerRulesInfo CallCenterTriggerRulesInfo { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;
}
