using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewRdpProductionPayments
{
    public int Id { get; set; }

    public int RdpProductionId { get; set; }

    public string CreditCardNo { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
