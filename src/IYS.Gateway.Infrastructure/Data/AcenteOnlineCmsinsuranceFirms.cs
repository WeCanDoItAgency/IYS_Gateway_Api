using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsinsuranceFirms
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string Name { get; set; } = null!;

    public string? FirmTitle { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? UrlAddress { get; set; }

    public string? Image { get; set; }

    public string? ImageThumb { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? LanguageId { get; set; }

    public string? MersisNo { get; set; }

    public string? Kep { get; set; }

    public string? Email { get; set; }

    public int? StaticPageId { get; set; }

    public int? DisplayOrder { get; set; }

    public string? HealthUrl { get; set; }

    public string? AutoServiceUrl { get; set; }

    public virtual ICollection<AcenteOnlineCmsinsuranceFirmBranchesMapping> AcenteOnlineCmsinsuranceFirmBranchesMapping { get; set; } = new List<AcenteOnlineCmsinsuranceFirmBranchesMapping>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;

    public virtual AcenteOnlineCmspages? StaticPage { get; set; }
}
