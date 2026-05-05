using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsinsuranceBranches
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? LanguageId { get; set; }

    public string? Image { get; set; }

    public string? ThumbImage { get; set; }

    public string? Url { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Icon { get; set; }

    public int? StaticPageId { get; set; }

    public string? Slug { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public virtual ICollection<AcenteOnlineCmsblogCategories> AcenteOnlineCmsblogCategories { get; set; } = new List<AcenteOnlineCmsblogCategories>();

    public virtual ICollection<AcenteOnlineCmscoverageCategories> AcenteOnlineCmscoverageCategories { get; set; } = new List<AcenteOnlineCmscoverageCategories>();

    public virtual ICollection<AcenteOnlineCmscustomerFeedbacks> AcenteOnlineCmscustomerFeedbacks { get; set; } = new List<AcenteOnlineCmscustomerFeedbacks>();

    public virtual ICollection<AcenteOnlineCmsfaqCategories> AcenteOnlineCmsfaqCategories { get; set; } = new List<AcenteOnlineCmsfaqCategories>();

    public virtual ICollection<AcenteOnlineCmsinsuranceFirmBranchesMapping> AcenteOnlineCmsinsuranceFirmBranchesMapping { get; set; } = new List<AcenteOnlineCmsinsuranceFirmBranchesMapping>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;

    public virtual AcenteOnlineCmspages? StaticPage { get; set; }
}
