using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SourceTokenCheck
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public string? Source { get; set; }

    public string? IpAddress { get; set; }

    public string? CompanyName { get; set; }

    public string? Detail { get; set; }

    public bool? IsCallCenterPrior { get; set; }

    public bool IsRequiredSmsapprove { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool IsPaymentEncrypted { get; set; }

    public bool IsLoginEncrypted { get; set; }

    public bool IsHaveSeeSiteRecordsPerm { get; set; }

    public bool IsRequireSmsLimitControl { get; set; }

    public bool IsMaster { get; set; }

    public virtual Subeler? Branch { get; set; }
}
