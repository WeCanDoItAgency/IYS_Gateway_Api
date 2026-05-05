using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VwPackageValuesTeklifMicro
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string? Name { get; set; }

    public int ControlTypeId { get; set; }

    public int DisplayOrder { get; set; }

    public string? ApiName { get; set; }

    public bool? ApiyeGonderilsinMi { get; set; }

    public bool? OtomatikSistemeGonderilsinMi { get; set; }

    public string? AttributeValue { get; set; }

    public string? AttributeName { get; set; }

    public int GroupId { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryDisplayOrder { get; set; }

    public string? GroupName { get; set; }

    public int? VehicleType { get; set; }

    public bool? BrandAttributeValueIsActive { get; set; }

    public bool? BrandAttributeGroupValueIsActive { get; set; }

    public bool? BrandAttributeIsActive { get; set; }

    public bool? BrandAttributeGroupTypeIsActive { get; set; }

    public int? BotBrandAttributeValueId { get; set; }

    public string? BotBrandAttributeValueName { get; set; }

    public string? BotBrandAttributeValue { get; set; }

    public string? BotApiName { get; set; }

    public bool? IsDependencyAge { get; set; }

    public Guid PackageGuid { get; set; }

    public int BrandAttributeGroupValueId { get; set; }

    public string? ServicePropertyName { get; set; }

    public bool? ShowInCenterWaiting { get; set; }

    public bool? OrtakDegerMi { get; set; }

    public int? BrandAttributeType { get; set; }
}
