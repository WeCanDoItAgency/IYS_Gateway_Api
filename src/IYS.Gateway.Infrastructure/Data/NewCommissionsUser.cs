using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCommissionsUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SubeId { get; set; }

    public int FirmId { get; set; }

    public int QueryTypeId { get; set; }

    public int? SubBrandId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? EndDateFirstRecord { get; set; }

    public decimal? AssuranceRate { get; set; }

    public decimal? Rate { get; set; }

    public decimal? CommissionAmount { get; set; }

    public int? CommissionType { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool IsActive { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual NewQueryTypes QueryType { get; set; } = null!;

    public virtual NewSubBrands? SubBrand { get; set; }
}
