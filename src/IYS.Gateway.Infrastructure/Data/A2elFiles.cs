using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class A2elFiles
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BaslikId { get; set; }

    public string? FilePath { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }
}
