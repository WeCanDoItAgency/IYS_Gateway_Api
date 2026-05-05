using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Sendlogs
{
    public int Id { get; set; }

    public int TypId { get; set; }

    public int ProcessId { get; set; }

    public int KuserId { get; set; }

    public string WbStatus { get; set; } = null!;

    public bool IsSuccess { get; set; }

    public DateTime CreateDate { get; set; }
}
