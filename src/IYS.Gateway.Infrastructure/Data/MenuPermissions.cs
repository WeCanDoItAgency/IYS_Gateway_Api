using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MenuPermissions
{
    public int Id { get; set; }

    public string MenuDescription { get; set; } = null!;

    public string MenuPermission { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsChild { get; set; }

    public int? ParentId { get; set; }

    public string? Url { get; set; }

    public bool OnlyRoot { get; set; }

    public virtual ICollection<MenuPermissions> InverseParent { get; set; } = new List<MenuPermissions>();

    public virtual ICollection<PackagePermissionMappings> PackagePermissionMappings { get; set; } = new List<PackagePermissionMappings>();

    public virtual MenuPermissions? Parent { get; set; }
}
