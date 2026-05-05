using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCommissions
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? BranchId { get; set; }

    public int QueryTypeId { get; set; }

    public int? SubBrandId { get; set; }

    public decimal? Rate { get; set; }

    public decimal? AssuranceRate { get; set; }

    public int CommissionType { get; set; }

    public decimal? CommissionAmount { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? SktRequestId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool IsActive { get; set; }

    public virtual NewQueryTypes QueryType { get; set; } = null!;

    public virtual NewSubBrands? SubBrand { get; set; }
}
