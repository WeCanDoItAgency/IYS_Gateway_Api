using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountPlanAccountTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<NewAccountancyPlannings> NewAccountancyPlannings { get; set; } = new List<NewAccountancyPlannings>();
}
