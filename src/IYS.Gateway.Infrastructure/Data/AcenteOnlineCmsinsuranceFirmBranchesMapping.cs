using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsinsuranceFirmBranchesMapping
{
    public int Id { get; set; }

    public int InsuranceFirmId { get; set; }

    public int InsuranceBranchId { get; set; }

    public virtual AcenteOnlineCmsinsuranceBranches InsuranceBranch { get; set; } = null!;

    public virtual AcenteOnlineCmsinsuranceFirms InsuranceFirm { get; set; } = null!;
}
