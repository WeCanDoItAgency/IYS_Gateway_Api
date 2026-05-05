using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewReferenceMappings
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? Prefix { get; set; }

    public int? NextRef { get; set; }

    public bool? IsActive { get; set; }
}
