using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MarkaModelAllianz
{
    public int Id { get; set; }

    public int? ModelYear { get; set; }

    public string? UsageManner { get; set; }

    public string? UsageSubstance { get; set; }

    public string? MakeCode { get; set; }

    public string? MakeName { get; set; }

    public string? ModelCode { get; set; }

    public string? ModelName { get; set; }

    public double? VehicleAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }
}
