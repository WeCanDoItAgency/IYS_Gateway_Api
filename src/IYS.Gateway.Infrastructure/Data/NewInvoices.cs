using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewInvoices
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public int TypeId { get; set; }

    public string RefNo { get; set; } = null!;

    public DateTime Date { get; set; }

    public int FirmId { get; set; }

    public int CariKartId { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal DiscountRatio { get; set; }

    public decimal NetAmount { get; set; }

    public int? VatRatioId { get; set; }

    public decimal VatAmount { get; set; }

    public decimal VatIncludedTotalAmount { get; set; }

    public int CurrencyId { get; set; }

    public string? Note { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual NewCurrencies Currency { get; set; } = null!;

    public virtual ICollection<NewInvoiceItems> NewInvoiceItems { get; set; } = new List<NewInvoiceItems>();
}
