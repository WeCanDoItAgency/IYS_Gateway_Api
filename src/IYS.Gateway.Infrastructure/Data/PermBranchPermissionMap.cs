using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermBranchPermissionMap
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
