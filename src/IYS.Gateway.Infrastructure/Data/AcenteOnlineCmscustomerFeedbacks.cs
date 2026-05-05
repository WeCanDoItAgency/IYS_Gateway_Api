using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmscustomerFeedbacks
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerImage { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? InsuranceBranchId { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmsinsuranceBranches? InsuranceBranch { get; set; }

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
