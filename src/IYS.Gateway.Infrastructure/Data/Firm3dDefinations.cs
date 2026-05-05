using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Firm3dDefinations
{
    public int Id { get; set; }

    public string? Endpoint { get; set; }

    public string? PaytenMerchant { get; set; }

    public string? PaytenMerchantUser { get; set; }

    public string? PaytenMerchantPassword { get; set; }

    public bool? IsActive { get; set; }

    public int? FirmId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
