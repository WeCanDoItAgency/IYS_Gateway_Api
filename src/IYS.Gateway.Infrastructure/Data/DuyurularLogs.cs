using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DuyurularLogs
{
    public int Id { get; set; }

    public int? DId { get; set; }

    public int? UId { get; set; }

    public DateTime? Tarih { get; set; }
}
