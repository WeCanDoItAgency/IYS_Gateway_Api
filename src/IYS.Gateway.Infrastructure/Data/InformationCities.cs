using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationCities
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<InformationDistricts> InformationDistricts { get; set; } = new List<InformationDistricts>();
}
