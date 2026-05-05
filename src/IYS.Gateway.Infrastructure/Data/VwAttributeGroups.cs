using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VwAttributeGroups
{
    public int? BrandId { get; set; }

    public string? QueryType { get; set; }

    public string? Name { get; set; }

    public int? GroupType { get; set; }

    public string? ApiName { get; set; }

    public bool IsActive { get; set; }

    public string? Description { get; set; }

    public string? GroupName { get; set; }

    public bool? IsGroupActive { get; set; }

    public int Id { get; set; }

    public string? GroupNameDescription { get; set; }

    public string? ShortName { get; set; }

    public bool? ShowBuyButton { get; set; }

    public int? VehicleType { get; set; }

    public int BranchId { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid PackageGuid { get; set; }
}
