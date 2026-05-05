using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdplicenseRequests
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RequestId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Note { get; set; }

    public string? SmsCode { get; set; }

    public bool SmsApproved { get; set; }

    public DateTime? SmsApproveDate { get; set; }

    public bool? LicenceRenewal { get; set; }

    public string? OldLicenceCode { get; set; }

    public string? NewLicenceCode { get; set; }
}
