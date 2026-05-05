using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajSubUsers
{
    public int Id { get; set; }

    public int RdpBrandPartajId { get; set; }

    public string? AgentUserName { get; set; }

    public string? AgentPassword { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? SmsQrId { get; set; }

    public string? MfaSecret { get; set; }

    public bool? IsMfa { get; set; }

    public string? MfaCode { get; set; }

    public int? SubUserPlatformType { get; set; }

    public virtual NewRdpBrandPartajs RdpBrandPartaj { get; set; } = null!;
}
