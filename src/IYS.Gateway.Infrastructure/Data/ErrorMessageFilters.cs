using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ErrorMessageFilters
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? TypeId { get; set; }

    public int InsuranceId { get; set; }

    public string QueryType { get; set; } = null!;

    public bool? Action { get; set; }

    public int? VehicleType { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool IsActive { get; set; }

    public bool? FirmIdyeOzelMi { get; set; }

    public bool? ExcludeAll { get; set; }
}
