using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewPurchaseOfferItems
{
    public int Id { get; set; }

    public int? PurchaseRequestItemId { get; set; }

    public int? PurchaseOrderItemId { get; set; }

    public int? CariKartId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? UomId { get; set; }

    public decimal? Quantity { get; set; }

    public int? PurchaseOfferId { get; set; }

    public int? CurrencyId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
