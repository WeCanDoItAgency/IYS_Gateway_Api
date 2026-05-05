using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsBlogFaqs
{
    public int Id { get; set; }

    public int BlogId { get; set; }

    public string? Soru { get; set; }

    public string? Cevap { get; set; }

    public bool? IsActive { get; set; }

    public virtual AcenteOnlineCmsblogPosts Blog { get; set; } = null!;
}
