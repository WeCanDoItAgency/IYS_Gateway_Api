using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifNotlar
{
    public int Id { get; set; }

    public int? TeklifId { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? KuserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Aciklama { get; set; }

    public string? Type { get; set; }

    public int? NotId { get; set; }
}
