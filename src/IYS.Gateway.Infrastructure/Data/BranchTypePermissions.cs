using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchTypePermissions
{
    public int Id { get; set; }

    public int? BranchTypeId { get; set; }

    public string? PermissionName { get; set; }

    public bool? PermissionSate { get; set; }
}
