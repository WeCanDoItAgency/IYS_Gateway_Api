using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmspages
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string PageTitle { get; set; } = null!;

    public string PageContent { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int LanguageId { get; set; }

    public int Status { get; set; }

    public bool? IsActive { get; set; }

    public string PageName { get; set; } = null!;

    public int ViewCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsListed { get; set; }

    public bool? AddWithCategoryToSitemap { get; set; }

    public bool? IsIndexed { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual ICollection<AcenteOnlineCmsPageFaqs> AcenteOnlineCmsPageFaqs { get; set; } = new List<AcenteOnlineCmsPageFaqs>();

    public virtual ICollection<AcenteOnlineCmsinsuranceBranches> AcenteOnlineCmsinsuranceBranches { get; set; } = new List<AcenteOnlineCmsinsuranceBranches>();

    public virtual ICollection<AcenteOnlineCmsinsuranceFirms> AcenteOnlineCmsinsuranceFirms { get; set; } = new List<AcenteOnlineCmsinsuranceFirms>();

    public virtual AcenteOnlineCmspageCategories? Category { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmslanguages Language { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
