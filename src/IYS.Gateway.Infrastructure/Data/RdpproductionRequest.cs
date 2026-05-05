using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpproductionRequest
{
    public int Id { get; set; }

    public string? Filename { get; set; }

    public int? QueryTypeId { get; set; }

    public int? FirmId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Status { get; set; }

    public int? Sktid { get; set; }
}
