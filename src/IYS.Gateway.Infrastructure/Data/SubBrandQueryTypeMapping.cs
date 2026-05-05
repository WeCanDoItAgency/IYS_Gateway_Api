using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubBrandQueryTypeMapping
{
    public int Id { get; set; }

    public int? SubBrandId { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }

    public virtual NewSubBrands? SubBrand { get; set; }
}
