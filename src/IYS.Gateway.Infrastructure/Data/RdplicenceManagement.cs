using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdplicenceManagement
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? SktId { get; set; }

    public int? FirmId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LicenceStartDate { get; set; }

    public DateTime? LicenceExpireDate { get; set; }

    public string? Note { get; set; }

    public string? Licence { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }
}
