using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterTriggerRulesInfoSktMapping
{
    public int Id { get; set; }

    public int SktId { get; set; }

    public int CallCenterTriggerRulesInfoId { get; set; }

    public bool? IsActive { get; set; }

    public virtual CallCenterTriggerRulesInfo CallCenterTriggerRulesInfo { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
