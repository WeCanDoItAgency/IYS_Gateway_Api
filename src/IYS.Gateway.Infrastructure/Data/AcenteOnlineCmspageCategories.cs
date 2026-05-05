using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmspageCategories
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public int? ParentId { get; set; }

    public int? LanguageId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual ICollection<AcenteOnlineCmspages> AcenteOnlineCmspages { get; set; } = new List<AcenteOnlineCmspages>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual ICollection<AcenteOnlineCmspageCategories> InverseParent { get; set; } = new List<AcenteOnlineCmspageCategories>();

    public virtual AcenteOnlineCmslanguages? Language { get; set; }

    public virtual AcenteOnlineCmspageCategories? Parent { get; set; }

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
