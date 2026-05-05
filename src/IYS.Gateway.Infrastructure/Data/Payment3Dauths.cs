using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Payment3Dauths
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int InsuranceId { get; set; }

    public string QueryType { get; set; } = null!;

    public bool? IsPayment { get; set; }

    public bool Payment3D { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
