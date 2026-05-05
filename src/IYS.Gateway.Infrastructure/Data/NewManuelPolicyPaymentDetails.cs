using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewManuelPolicyPaymentDetails
{
    public int Id { get; set; }

    public int? ManuelPolicyId { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Installement { get; set; }

    public double? InstallementPrice { get; set; }

    public bool? IsMailOrder { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsPaid { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeletedUserId { get; set; }

    public virtual NewManuelPolicies? ManuelPolicy { get; set; }
}
