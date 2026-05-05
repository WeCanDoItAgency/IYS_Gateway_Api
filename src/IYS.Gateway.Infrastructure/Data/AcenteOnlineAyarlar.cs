using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineAyarlar
{
    public int Id { get; set; }

    public Guid? Guid { get; set; }

    public int? FirmaId { get; set; }

    public int? SubeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? SeoKeywords { get; set; }

    public string? PublicKey { get; set; }

    public string? PrivateKey { get; set; }

    public string? Url { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
