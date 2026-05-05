using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewIncOutReceipts
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }

    public decimal StandardAmount { get; set; }

    public decimal? CovidGuaranteedAmount { get; set; }

    public int StandardAmountCurrencyId { get; set; }

    public int? CovidGuaranteedAmountCurrencyId { get; set; }

    public int DaysId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
