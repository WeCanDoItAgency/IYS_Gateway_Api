using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CarQueryRequest
{
    public int Id { get; set; }

    public int QuerytypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int Status { get; set; }

    public int FirmId { get; set; }

    public bool IsPolice { get; set; }

    public bool? PolicesiBitmisOlanlarDahilEdilsinMi { get; set; }

    public bool? IsAutoRequest { get; set; }

    public string? FilePath { get; set; }

    public string? ErrorMessage { get; set; }
}
