using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermFirmPermissions
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? BranchId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int CreatUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public int? PermissionId { get; set; }

    public virtual PermissionList? Permission { get; set; }
}
