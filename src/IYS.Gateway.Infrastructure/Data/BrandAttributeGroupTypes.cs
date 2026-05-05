using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeGroupTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<BrandAttibuteGroupTypeIsShowCwmap> BrandAttibuteGroupTypeIsShowCwmap { get; set; } = new List<BrandAttibuteGroupTypeIsShowCwmap>();
}
