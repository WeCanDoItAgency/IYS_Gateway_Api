using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewUniversities
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }
}
