using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CustomerTagInformation
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string? CustomerTagName { get; set; }

    public int MinPuan { get; set; }

    public int MaxPuan { get; set; }

    public int? IndirimTipi { get; set; }

    public int? Indirim { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;
}
