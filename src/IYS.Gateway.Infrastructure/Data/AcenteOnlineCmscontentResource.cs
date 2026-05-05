using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmscontentResource
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public string ResourceKey { get; set; } = null!;

    public string ResourceValue { get; set; } = null!;

    public int LanguageId { get; set; }

    public string? FriendlyName { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual AcenteOnlineCmslanguages Language { get; set; } = null!;
}
