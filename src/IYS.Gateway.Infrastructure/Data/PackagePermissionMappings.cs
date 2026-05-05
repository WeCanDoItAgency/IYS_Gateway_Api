using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PackagePermissionMappings
{
    public int Id { get; set; }

    public int? PackageId { get; set; }

    public int? PermissionId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual Packages? Package { get; set; }

    public virtual MenuPermissions? Permission { get; set; }
}
