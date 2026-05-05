using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterCustomerAgreementLog
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public int? CallCenterCustomerAgreementsId { get; set; }

    public string? TcKimlikNo { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual CallCenterCustomerAgreements? CallCenterCustomerAgreements { get; set; }
}
