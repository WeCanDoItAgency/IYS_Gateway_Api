using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationDistricts
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual InformationCities City { get; set; } = null!;

    public virtual ICollection<InformationTowns> InformationTowns { get; set; } = new List<InformationTowns>();
}
