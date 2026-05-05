using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifTyorum
{
    public int Id { get; set; }

    public int? TeklifId { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? KuserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? DurumId { get; set; }
}
