using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterCustomerAgreements
{
    public int Id { get; set; }

    public string AgreementText { get; set; } = null!;

    public virtual ICollection<CallCenterCustomerAgreementLog> CallCenterCustomerAgreementLog { get; set; } = new List<CallCenterCustomerAgreementLog>();
}
