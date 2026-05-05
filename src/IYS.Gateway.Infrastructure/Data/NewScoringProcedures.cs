using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewScoringProcedures
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? UserId { get; set; }

    public int? FeeTypeId { get; set; }

    public int? NumberOfDays { get; set; }

    public decimal? TotalGain { get; set; }

    public decimal? AdditionalAllowance { get; set; }

    public decimal? TotalDeduction { get; set; }

    public decimal? NetWages { get; set; }

    public string? Description { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
