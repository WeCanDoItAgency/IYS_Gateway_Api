using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Branchauths
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int SigortaId { get; set; }

    public bool IsWbsrvc { get; set; }

    public bool IsWbsrvce { get; set; }

    public bool IsDesktop { get; set; }
}
