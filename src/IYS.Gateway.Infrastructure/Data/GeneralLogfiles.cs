using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GeneralLogfiles
{
    public int Id { get; set; }

    public string? Logfile { get; set; }

    public int? GeneralLogId { get; set; }
}
