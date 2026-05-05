using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SignatureControls
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int InsuranceId { get; set; }

    public string QueryType { get; set; } = null!;

    public bool Status { get; set; }

    public bool IsSigning { get; set; }

    public bool IsVirtualSigning { get; set; }

    public DateTime CreateDate { get; set; }

    public bool? IsSpecialSign { get; set; }
}
