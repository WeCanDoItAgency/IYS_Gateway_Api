using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewProductGroups
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int ProductFamilyId { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual ICollection<NewProductSubGroups> NewProductSubGroups { get; set; } = new List<NewProductSubGroups>();

    public virtual NewProductFamilies ProductFamily { get; set; } = null!;
}
