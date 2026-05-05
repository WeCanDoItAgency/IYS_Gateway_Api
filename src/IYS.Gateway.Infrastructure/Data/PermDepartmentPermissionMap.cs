using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermDepartmentPermissionMap
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
