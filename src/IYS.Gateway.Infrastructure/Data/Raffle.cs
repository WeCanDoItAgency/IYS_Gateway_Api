using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Raffle
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Banner { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? EndDate { get; set; }
}
