using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationNeighborhoods
{
    public int Id { get; set; }

    public int TownId { get; set; }

    public int Code { get; set; }

    public string? Name { get; set; }

    public int QuarterTypeCode { get; set; }

    public int VillageCode { get; set; }

    public virtual ICollection<InformationStreets> InformationStreets { get; set; } = new List<InformationStreets>();

    public virtual InformationTowns Town { get; set; } = null!;
}
