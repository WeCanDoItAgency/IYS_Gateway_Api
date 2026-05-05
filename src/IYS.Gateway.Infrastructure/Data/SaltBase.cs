using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SaltBase
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsUsed { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public int? CreatedBy { get; set; }

    public int? UsedBy { get; set; }

    public string? CreatedFrom { get; set; }

    public DateTime? UsedDate { get; set; }
}
