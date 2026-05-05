using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Packages
{
    public int Id { get; set; }

    public string? PackageCode { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<FirmPackageAggrements> FirmPackageAggrements { get; set; } = new List<FirmPackageAggrements>();

    public virtual ICollection<PackagePermissionMappings> PackagePermissionMappings { get; set; } = new List<PackagePermissionMappings>();
}
