using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracModelKodlariAractipiMap
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string BrandCode { get; set; } = null!;

    public string ModelCode { get; set; } = null!;

    public int VehicleType { get; set; }

    public string QueryType { get; set; } = null!;
}
