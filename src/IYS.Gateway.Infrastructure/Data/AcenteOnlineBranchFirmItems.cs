using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineBranchFirmItems
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public Guid? Guid { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? SeoKeywords { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
