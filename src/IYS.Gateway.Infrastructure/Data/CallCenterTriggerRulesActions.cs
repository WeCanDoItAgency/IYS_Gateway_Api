using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterTriggerRulesActions
{
    public int Id { get; set; }

    public int CallCenterTriggerRulesId { get; set; }

    public bool? ByPass { get; set; }

    public int? Minute { get; set; }

    public int? PhoneType { get; set; }

    public int? MessageType { get; set; }

    public string? MessageText { get; set; }

    public int? Queue { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual CallCenterTriggerRules CallCenterTriggerRules { get; set; } = null!;
}
