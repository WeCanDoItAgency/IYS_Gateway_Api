using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmscoveragePosts
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostContent { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? PostImagePath { get; set; }

    public string? PostThumbImagePath { get; set; }

    public int CategoryId { get; set; }

    public int Status { get; set; }

    public bool IsActive { get; set; }

    public int LanguageId { get; set; }

    public string? Summary { get; set; }

    public string? VideoUrl { get; set; }

    public int? ViewCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public bool? ShowInHome { get; set; }

    public virtual AcenteOnlineCmscoverageCategories Category { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmslanguages Language { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
