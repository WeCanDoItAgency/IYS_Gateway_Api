using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsPageFaqs
{
    public int Id { get; set; }

    public int PageId { get; set; }

    public string? Soru { get; set; }

    public string? Cevap { get; set; }

    public bool? IsActive { get; set; }

    public virtual AcenteOnlineCmspages Page { get; set; } = null!;
}
