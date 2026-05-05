using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubQueryRules
{
    public int Id { get; set; }

    public int QueryRulesId { get; set; }

    public int QueryTypeId { get; set; }

    public int QueryRulesActionTypeId { get; set; }

    public bool IsActive { get; set; }

    public int Limit { get; set; }

    public int? SubBrandId { get; set; }

    public virtual QueryRules QueryRules { get; set; } = null!;

    public virtual NewSubBrands? SubBrand { get; set; }
}
