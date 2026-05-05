using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineFaq
{
    public int Id { get; set; }

    public Guid? Guid { get; set; }

    public string? SeoKeywords { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public string? Description { get; set; }

    public int? FirmaId { get; set; }

    public string? Url { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaTitle { get; set; }

    public int? DisplayOrder { get; set; }
}
