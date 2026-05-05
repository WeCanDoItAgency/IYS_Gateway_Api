using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SessionControls
{
    public long Id { get; set; }

    public string? UserCode { get; set; }

    public string? SessionCode { get; set; }

    public string? ProcessCode { get; set; }

    public DateTime CreateDate { get; set; }

    public int UserId { get; set; }

    public bool IsClosed { get; set; }
}
