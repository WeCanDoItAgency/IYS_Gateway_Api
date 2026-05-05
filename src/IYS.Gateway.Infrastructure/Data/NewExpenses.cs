using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewExpenses
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public string RefNo { get; set; } = null!;

    public int StatusId { get; set; }

    public string? Note { get; set; }

    public int CurrencyId { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? DiscountRatio { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public int? VatRatioId { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? VatIncludedTotalAmount { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
