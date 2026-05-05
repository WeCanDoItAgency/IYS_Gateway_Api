using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermBranchTypePermissionMap
{
    public int Id { get; set; }

    public int? BranchTypeId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
