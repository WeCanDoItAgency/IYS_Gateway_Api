using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallRequestTypes
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public int? TypeCode { get; set; }

    public int? FirmId { get; set; }

    public int? CallAfterXminute { get; set; }

    public int? CallCenterSymbolId { get; set; }

    public virtual ICollection<ExpertiseRequests> ExpertiseRequests { get; set; } = new List<ExpertiseRequests>();
}
