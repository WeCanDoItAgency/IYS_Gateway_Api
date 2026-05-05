using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeGroupFuelTypeMapping
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public Guid PackageGuid { get; set; }

    public int FuelTypeId { get; set; }

    public int? ReferencePackageId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }
}
