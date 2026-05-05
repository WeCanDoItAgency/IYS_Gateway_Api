using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewReferences
{
    public int Id { get; set; }

    public string Prefix { get; set; } = null!;

    public bool? IsActive { get; set; }
}
