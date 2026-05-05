using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationStreets
{
    public int Id { get; set; }

    public int NeighborhoodId { get; set; }

    public int Code { get; set; }

    public int IdentificationCode { get; set; }

    public string? Name { get; set; }

    public int QuarterCode { get; set; }

    public int StreetTypeCode { get; set; }

    public string? StreetTypeExplanation { get; set; }

    public virtual ICollection<InformationApartments> InformationApartments { get; set; } = new List<InformationApartments>();

    public virtual InformationNeighborhoods Neighborhood { get; set; } = null!;
}
