using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VisitorCountLog
{
    public int Id { get; set; }

    public string? VisitorCode { get; set; }

    public int? VisitCount { get; set; }
}
