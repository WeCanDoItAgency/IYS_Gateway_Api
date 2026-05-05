using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CouponCodes
{
    public int Id { get; set; }

    public string? CouponCode { get; set; }

    public int? PaymentId { get; set; }

    public int? DetailId { get; set; }

    public int? HeaderId { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsPolicy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsActive { get; set; }
}
