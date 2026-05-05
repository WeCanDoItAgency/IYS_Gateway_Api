using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineBranchFirms
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public Guid? Guid { get; set; }

    public string Name { get; set; } = null!;

    public string? FirmTitle { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public string? SeoKeywords { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? KepAddress { get; set; }

    public string? MersisNo { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
