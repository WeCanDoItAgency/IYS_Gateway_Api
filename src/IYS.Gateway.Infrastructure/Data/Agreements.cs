using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Agreements
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public string? TypeName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateUserId { get; set; }

    public string? Content { get; set; }
}
