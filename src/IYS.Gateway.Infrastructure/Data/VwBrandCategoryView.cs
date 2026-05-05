using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VwBrandCategoryView
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string? Name { get; set; }

    public int ControlTypeId { get; set; }

    public int DisplayOrder { get; set; }

    public bool? PolicyDetailVisible { get; set; }

    public string? ApiName { get; set; }

    public bool DontSendApi { get; set; }

    public int? CategoryId { get; set; }

    public bool? CompareVisible { get; set; }

    public string? QueryType { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryDisplayOrder { get; set; }

    public string? CategoryDescription { get; set; }

    public string? Description { get; set; }

    public bool? DescriptionVisible { get; set; }

    public int? VehicleType { get; set; }

    public int? BrandAttributeType { get; set; }

    public bool? ReWorkIfInstallmentChanges { get; set; }
}
