using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineWidgets
{
    public int Id { get; set; }

    public string? SeoKeywords { get; set; }

    public Guid? ParentGuid { get; set; }

    public Guid? Guid { get; set; }

    public string Code { get; set; } = null!;

    public int FirmaId { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public string? SubTitle { get; set; }

    public string? Description { get; set; }

    public string? DescriptionClass { get; set; }

    public string? SubClass { get; set; }

    public string? Link { get; set; }

    public string? ImageUrl { get; set; }

    public string? BackgorundImageUrl { get; set; }

    public string? Fileurl { get; set; }

    public string? Icon { get; set; }

    public string? ButtonColor { get; set; }

    public string? ButtonClass { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
