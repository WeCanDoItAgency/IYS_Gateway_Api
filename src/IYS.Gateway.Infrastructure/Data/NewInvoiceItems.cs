using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewInvoiceItems
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string? ProductName { get; set; }

    public int? ProductId { get; set; }

    public int UomId { get; set; }

    public int CurrencyId { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal Quantity { get; set; }

    public decimal NetAmount { get; set; }

    public decimal VatIncludedTotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal DiscountRatio { get; set; }

    public int? VatRatioId { get; set; }

    public decimal? VatAmount { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual NewInvoices Invoice { get; set; } = null!;
}
