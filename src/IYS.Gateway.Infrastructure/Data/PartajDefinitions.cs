using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PartajDefinitions
{
    public int Id { get; set; }

    public string AgencyName { get; set; } = null!;

    public int BrandId { get; set; }

    public string PartajCode { get; set; } = null!;

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewBrands Brand { get; set; } = null!;
}
