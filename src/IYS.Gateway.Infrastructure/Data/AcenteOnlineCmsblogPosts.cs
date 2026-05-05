using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsblogPosts
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

    public string PostSummary { get; set; } = null!;

    public int ViewCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public bool? IsCampaign { get; set; }

    public int? CampaignId { get; set; }

    public string? CampaignBanner { get; set; }

    public string? CampaignBranchSlug { get; set; }

    public int? CampaignBranchId { get; set; }

    public bool? CampaignShowForm { get; set; }

    public string? PostImageMobilePath { get; set; }

    public bool? IsNews { get; set; }

    public bool ExcludeFromSitemap { get; set; }

    public bool? IsFollow { get; set; }

    public int? BlogType { get; set; }

    public bool? IsPopular { get; set; }

    public int? OfferForm { get; set; }

    public int? DisplayOrder { get; set; }

    public int? ReplacementPeriod { get; set; }

    public DateTime? PublishDate { get; set; }

    public virtual ICollection<AcenteOnlineCmsBlogFaqs> AcenteOnlineCmsBlogFaqs { get; set; } = new List<AcenteOnlineCmsBlogFaqs>();

    public virtual ICollection<AcenteOnlineCmsblogPostTagsMappings> AcenteOnlineCmsblogPostTagsMappings { get; set; } = new List<AcenteOnlineCmsblogPostTagsMappings>();

    public virtual Campaigns? Campaign { get; set; }

    public virtual AcenteOnlineCmsblogCategories Category { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmslanguages Language { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
