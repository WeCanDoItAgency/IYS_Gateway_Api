using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Gruplar
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsVisibleForSite { get; set; }

    public bool Isactive { get; set; }
}
