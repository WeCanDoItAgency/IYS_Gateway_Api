using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InformationHomes
{
    public int Id { get; set; }

    public int ApartmentId { get; set; }

    public string UavtCode { get; set; } = null!;

    public int BuildingCode { get; set; }

    public int Code { get; set; }

    public int InnerDoorNum { get; set; }

    public int TuikCode { get; set; }

    public int UsageTypeCode { get; set; }
}
