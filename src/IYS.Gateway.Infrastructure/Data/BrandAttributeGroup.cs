using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeGroup
{
    public int Id { get; set; }

    public int? BrandId { get; set; }

    public int BranchId { get; set; }

    public string? QueryType { get; set; }

    public string? ApiName { get; set; }

    public int? GroupType { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? VehicleType { get; set; }

    public int? UserId { get; set; }

    public bool? ShowBuyButton { get; set; }

    public bool? Referance { get; set; }

    public int? ReferanceId { get; set; }

    public int? DisplayOrder { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public Guid PackageGuid { get; set; }

    public bool? StyleOptionsIsVertical { get; set; }

    public string? StyleOptionsTitle { get; set; }

    public string? StyleOptionsColor { get; set; }

    public int? StyleOptionsEnUygunSira { get; set; }

    public int? StyleOptionsSizeOzelSira { get; set; }

    public int? StyleOptionsEnKapsamliSira { get; set; }

    public virtual Subeler Branch { get; set; } = null!;

    public virtual NewBrands? Brand { get; set; }

    public virtual ICollection<BrandAttributeGroupValues> BrandAttributeGroupValues { get; set; } = new List<BrandAttributeGroupValues>();

    public virtual ICollection<PackagesExceptCities> PackagesExceptCities { get; set; } = new List<PackagesExceptCities>();
}
