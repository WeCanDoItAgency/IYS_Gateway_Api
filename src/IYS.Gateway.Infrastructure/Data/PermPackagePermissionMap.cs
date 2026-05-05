using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermPackagePermissionMap
{
    public int Id { get; set; }

    public int? PackageId { get; set; }

    public int? PermissionId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
