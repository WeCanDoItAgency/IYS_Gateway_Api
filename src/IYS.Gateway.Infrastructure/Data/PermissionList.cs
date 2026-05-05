using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PermissionList
{
    public int Id { get; set; }

    public string MenuDescription { get; set; } = null!;

    public string MenuPermission { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsChild { get; set; }

    public int? ParentId { get; set; }

    public string? Url { get; set; }

    public bool OnlyRoot { get; set; }

    public virtual ICollection<PermBranchPermissionMap> PermBranchPermissionMap { get; set; } = new List<PermBranchPermissionMap>();

    public virtual ICollection<PermBranchTypePermissionMap> PermBranchTypePermissionMap { get; set; } = new List<PermBranchTypePermissionMap>();

    public virtual ICollection<PermDepartmentPermissionMap> PermDepartmentPermissionMap { get; set; } = new List<PermDepartmentPermissionMap>();

    public virtual ICollection<PermFirmPermissions> PermFirmPermissions { get; set; } = new List<PermFirmPermissions>();

    public virtual ICollection<PermPackagePermissionMap> PermPackagePermissionMap { get; set; } = new List<PermPackagePermissionMap>();

    public virtual ICollection<PermUserPermissions> PermUserPermissions { get; set; } = new List<PermUserPermissions>();

    public virtual ICollection<PermUserRolePermissionMap> PermUserRolePermissionMap { get; set; } = new List<PermUserRolePermissionMap>();
}
