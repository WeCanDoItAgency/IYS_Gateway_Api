using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Mutabakat
{
    public int Id { get; set; }

    public Guid? MutabakatGuid { get; set; }

    public int PeriodId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int SktYetkiliUserId { get; set; }

    public decimal? GrossPremium { get; set; }

    public decimal? NetPremium { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsSent { get; set; }

    public int? SentUserId { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsDenied { get; set; }

    public string? DeniedReasonNote { get; set; }

    public int? RepliedByUserId { get; set; }

    public DateTime? RepliedDate { get; set; }

    public string? RepliedIpAddress { get; set; }

    public string? RepliedUserAgent { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual NewAccountingProductionPeriodOpenClose Period { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
