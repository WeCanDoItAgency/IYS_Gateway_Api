using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsblogTags
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public string TagName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int BlogPostTagsMappingsId { get; set; }

    public int? PgId { get; set; }

    public virtual ICollection<AcenteOnlineCmsblogPostTagsMappings> AcenteOnlineCmsblogPostTagsMappings { get; set; } = new List<AcenteOnlineCmsblogPostTagsMappings>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
