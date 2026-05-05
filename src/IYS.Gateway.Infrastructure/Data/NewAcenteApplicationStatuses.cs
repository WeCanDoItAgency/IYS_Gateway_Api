using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAcenteApplicationStatuses
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}
