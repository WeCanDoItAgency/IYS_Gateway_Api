using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmPackageAggrements
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int PackageId { get; set; }

    public bool? IsUserLimit { get; set; }

    public int? UserLimit { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? WebsiteUserLimit { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Packages Package { get; set; } = null!;
}
