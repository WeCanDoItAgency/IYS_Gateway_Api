using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationTowns
{
    public int Id { get; set; }

    public int DistrictId { get; set; }

    public int Code { get; set; }

    public int CityCode { get; set; }

    public int DistrictCode { get; set; }

    public string? TownshipName { get; set; }

    public string? TownshipVillageName { get; set; }

    public string? VillageNameText { get; set; }

    public virtual InformationDistricts District { get; set; } = null!;

    public virtual ICollection<InformationNeighborhoods> InformationNeighborhoods { get; set; } = new List<InformationNeighborhoods>();
}
