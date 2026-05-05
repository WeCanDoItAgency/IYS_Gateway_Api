using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeGroupValues
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int AttributeId { get; set; }

    public int ValueId { get; set; }

    public string Value { get; set; } = null!;

    public int? UserId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? AgeGroupId { get; set; }

    public bool? IsDependencyAge { get; set; }

    public int? BotValueId { get; set; }

    public int? SyncReferenceValueId { get; set; }

    public bool? ApiyeGonderilsinMi { get; set; }

    public bool? OtomatikSistemeGonderilsinMi { get; set; }

    public virtual BrandAttribute Attribute { get; set; } = null!;

    public virtual BrandAttributeGroup Group { get; set; } = null!;

    public virtual BrandAttributeValue ValueNavigation { get; set; } = null!;
}
