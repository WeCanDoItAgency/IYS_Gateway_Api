using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ApiControllers
{
    public int Id { get; set; }

    public string? Acente { get; set; }

    public string? AcenteUser { get; set; }

    public string? AcentePss { get; set; }

    public bool IsLocked { get; set; }
}
