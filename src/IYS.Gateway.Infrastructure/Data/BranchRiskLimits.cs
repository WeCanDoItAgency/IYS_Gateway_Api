using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchRiskLimits
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? QueryId { get; set; }

    public string? ProcessType { get; set; }

    public decimal? MaxAmount { get; set; }

    public int? DaysNumber { get; set; }

    public bool? Status { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
