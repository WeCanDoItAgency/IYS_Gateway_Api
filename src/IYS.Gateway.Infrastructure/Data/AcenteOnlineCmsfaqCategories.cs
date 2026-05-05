using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsfaqCategories
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int? ParentId { get; set; }

    public int? LanguageId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? InsuranceBranchId { get; set; }

    public virtual ICollection<AcenteOnlineCmsfaqPosts> AcenteOnlineCmsfaqPosts { get; set; } = new List<AcenteOnlineCmsfaqPosts>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmsinsuranceBranches? InsuranceBranch { get; set; }

    public virtual AcenteOnlineCmslanguages? Language { get; set; }

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
