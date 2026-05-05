using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewPurchaseOffers
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public int? PurchaseRequestId { get; set; }

    public string? RefNo { get; set; }

    public DateTime? Date { get; set; }

    public int? CurrencyId { get; set; }

    public string? Description { get; set; }

    public int? StatusId { get; set; }

    public int? CariKartId { get; set; }

    public int? PurchaseOrderId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
