using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserDayOffs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public string? ColorCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? Status { get; set; }

    public int? ApprovedUserId { get; set; }

    public int? UnApprovedUserId { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? UnApprovedDate { get; set; }

    public int? UserDayOffsType { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual Kullanicilar? User { get; set; }
}
