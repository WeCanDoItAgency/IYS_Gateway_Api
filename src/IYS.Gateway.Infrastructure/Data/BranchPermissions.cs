using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchPermissions
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public string PermissionName { get; set; } = null!;

    public bool PermissionSate { get; set; }
}
