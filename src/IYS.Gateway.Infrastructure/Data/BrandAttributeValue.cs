using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeValue
{
    public int Id { get; set; }

    public int BrandAttributeId { get; set; }

    public string? Name { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }

    public string? AttributeValue { get; set; }

    public string? Description { get; set; }

    public bool? DescriptionVisible { get; set; }

    public int? UserId { get; set; }

    public int BrandAttributeValueType { get; set; }

    public int? SyncReferenceAttributeValueId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsForBot { get; set; }

    public bool? OrtakDegerMi { get; set; }

    public int? ApiBotBrandAttributeValueMapId { get; set; }

    public string? MongoBrandAttributeValueEquals { get; set; }

    public virtual BrandAttribute BrandAttribute { get; set; } = null!;

    public virtual ICollection<BrandAttributeGroupValues> BrandAttributeGroupValues { get; set; } = new List<BrandAttributeGroupValues>();
}
