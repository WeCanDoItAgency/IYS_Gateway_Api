using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ReferanceCustomerCodes
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ReferanceCode { get; set; }

    public bool? IsActive { get; set; }

    public string? UserAgent { get; set; }

    public string? IpAddress { get; set; }

    public string? Device { get; set; }

    public virtual ICollection<ReferenceCustomerEntitledUserMapping> ReferenceCustomerEntitledUserMapping { get; set; } = new List<ReferenceCustomerEntitledUserMapping>();
}
