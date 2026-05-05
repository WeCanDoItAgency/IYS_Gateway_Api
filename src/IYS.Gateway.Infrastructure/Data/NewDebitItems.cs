using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewDebitItems
{
    public int Id { get; set; }

    public int DebitId { get; set; }

    public string? SerialNo { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public int UomId { get; set; }

    public decimal Quantity { get; set; }

    public int? ReturnStatusId { get; set; }

    public int? ProductBrandId { get; set; }

    public int? ProductModelId { get; set; }

    public string? Specifications { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
