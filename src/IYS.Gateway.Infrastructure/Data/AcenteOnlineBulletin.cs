using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineBulletin
{
    public int Id { get; set; }

    public string? SeoKeywords { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public string Email { get; set; } = null!;

    public string Ipaddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? IsActive { get; set; }

    public int? SiteId { get; set; }
}
