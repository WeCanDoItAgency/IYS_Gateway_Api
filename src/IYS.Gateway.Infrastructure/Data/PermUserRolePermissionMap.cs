using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermUserRolePermissionMap
{
    public int Id { get; set; }

    public int? UserRoleId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
