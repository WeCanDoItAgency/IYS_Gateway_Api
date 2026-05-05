using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttibuteGroupTypeIsShowCwmap
{
    public int Id { get; set; }

    public int BrandAttributeId { get; set; }

    public int GroupTypeId { get; set; }

    public bool Show { get; set; }

    public virtual BrandAttribute BrandAttribute { get; set; } = null!;

    public virtual BrandAttributeGroupTypes GroupType { get; set; } = null!;
}
