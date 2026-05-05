using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermUserPermissions
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
