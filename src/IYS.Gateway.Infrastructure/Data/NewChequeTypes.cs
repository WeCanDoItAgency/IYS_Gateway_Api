using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewChequeTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }
}
