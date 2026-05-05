using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCommunications
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int UserId { get; set; }

    public string? Note { get; set; }

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int StatusId { get; set; }

    public int CommReasonId { get; set; }

    public string? ColorCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Subeler Branch { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar User { get; set; } = null!;
}
