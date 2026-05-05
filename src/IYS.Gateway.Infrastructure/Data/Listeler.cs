using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Listeler
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int? ParentId { get; set; }

    public int ListKey { get; set; }

    public string ListTitle { get; set; } = null!;

    public bool Status { get; set; }

    public string? EgmTipkodu { get; set; }

    public bool? IsDefault { get; set; }

    public string? AlphaTwo { get; set; }

    public string? AlphaThree { get; set; }

    public bool? IsVisibleForSite { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
