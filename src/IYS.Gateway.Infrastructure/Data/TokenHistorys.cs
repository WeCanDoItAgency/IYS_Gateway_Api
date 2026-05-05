using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TokenHistorys
{
    public long Id { get; set; }

    public string Token { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime UpdateDate { get; set; }
}
