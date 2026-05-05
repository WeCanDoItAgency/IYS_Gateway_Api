using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VisitorStepTracking
{
    public int Id { get; set; }

    public string Visitor { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public int Step { get; set; }

    public string? IdentityNumber { get; set; }

    public string? Gsm { get; set; }

    public string? HeaderGuid { get; set; }

    public string? DetailGuid { get; set; }

    public int FromPlace { get; set; }

    public string Source { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
