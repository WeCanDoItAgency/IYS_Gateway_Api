using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajsBrandWebLinksMap
{
    public int Id { get; set; }

    public int? BrandWebLinksId { get; set; }

    public int? RdpBrandPartajsId { get; set; }

    public bool? IsActive { get; set; }

    public virtual BrandWebLinks? BrandWebLinks { get; set; }

    public virtual NewRdpBrandPartajs? RdpBrandPartajs { get; set; }
}
