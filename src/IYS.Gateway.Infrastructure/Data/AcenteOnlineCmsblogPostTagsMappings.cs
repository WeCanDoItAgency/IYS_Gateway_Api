using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsblogPostTagsMappings
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int TagId { get; set; }

    public virtual AcenteOnlineCmsblogPosts Post { get; set; } = null!;

    public virtual AcenteOnlineCmsblogTags Tag { get; set; } = null!;
}
