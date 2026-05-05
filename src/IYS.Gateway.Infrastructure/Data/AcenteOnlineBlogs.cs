using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineBlogs
{
    public int Id { get; set; }

    public string? SeoKeywords { get; set; }

    public int FirmId { get; set; }

    public string Title { get; set; } = null!;

    public string? TitleClass { get; set; }

    public Guid? Guid { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Summary { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public bool? IsActive { get; set; }

    public string? MetaTags { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }
}
