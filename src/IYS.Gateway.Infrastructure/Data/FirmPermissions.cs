using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmPermissions
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? BranchId { get; set; }

    public string PermissionMenuName { get; set; } = null!;

    public bool IsCompany { get; set; }

    public bool IsVisible { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int CreatUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;
}
