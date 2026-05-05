using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmslanguages
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string? Name { get; set; }

    public string? ShortCode { get; set; }

    public string? Icon { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual ICollection<AcenteOnlineCmsblogPosts> AcenteOnlineCmsblogPosts { get; set; } = new List<AcenteOnlineCmsblogPosts>();

    public virtual ICollection<AcenteOnlineCmscontentResource> AcenteOnlineCmscontentResource { get; set; } = new List<AcenteOnlineCmscontentResource>();

    public virtual ICollection<AcenteOnlineCmscoverageCategories> AcenteOnlineCmscoverageCategories { get; set; } = new List<AcenteOnlineCmscoverageCategories>();

    public virtual ICollection<AcenteOnlineCmscoveragePosts> AcenteOnlineCmscoveragePosts { get; set; } = new List<AcenteOnlineCmscoveragePosts>();

    public virtual ICollection<AcenteOnlineCmsfaqCategories> AcenteOnlineCmsfaqCategories { get; set; } = new List<AcenteOnlineCmsfaqCategories>();

    public virtual ICollection<AcenteOnlineCmsfaqPosts> AcenteOnlineCmsfaqPosts { get; set; } = new List<AcenteOnlineCmsfaqPosts>();

    public virtual ICollection<AcenteOnlineCmspageCategories> AcenteOnlineCmspageCategories { get; set; } = new List<AcenteOnlineCmspageCategories>();

    public virtual ICollection<AcenteOnlineCmspages> AcenteOnlineCmspages { get; set; } = new List<AcenteOnlineCmspages>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
