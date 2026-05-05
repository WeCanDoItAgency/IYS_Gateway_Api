using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationApartments
{
    public int Id { get; set; }

    public int StreetId { get; set; }

    public int BuildingNumber { get; set; }

    public int Code { get; set; }

    public int EqualBuildingCode { get; set; }

    public int LandBlock { get; set; }

    public int LandLot { get; set; }

    public string? LandSheet { get; set; }

    public string? OuterDoorNum { get; set; }

    public int QuarterCode { get; set; }

    public int StreetCode { get; set; }

    public int? UsageTypeCode { get; set; }

    public virtual InformationStreets Street { get; set; } = null!;
}
