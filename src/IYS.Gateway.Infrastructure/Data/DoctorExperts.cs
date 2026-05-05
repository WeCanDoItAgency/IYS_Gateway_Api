using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DoctorExperts
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int ListKey { get; set; }

    public string ListTitle { get; set; } = null!;

    public bool Status { get; set; }

    public string? Risk { get; set; }

    public bool? IsDefault { get; set; }

    public double? Price { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
