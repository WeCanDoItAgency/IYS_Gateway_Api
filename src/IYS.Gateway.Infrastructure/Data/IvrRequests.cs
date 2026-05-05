using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class IvrRequests
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public string? QueryType { get; set; }

    public int? DetailId { get; set; }

    public string? EncDetailId { get; set; }

    public string? ExpertiseGuid { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ApiResponse { get; set; }

    public bool IsJustForCvv { get; set; }

    public string? Column20Guid { get; set; }
}
