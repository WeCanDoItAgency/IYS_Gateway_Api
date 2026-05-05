using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewGeneralTargets
{
    public int Id { get; set; }

    public decimal? TargetAmount { get; set; }

    public int? TargetCount { get; set; }

    public int FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? DepartmentId { get; set; }

    public int? UserId { get; set; }

    public int TimeType { get; set; }

    public int TypeId { get; set; }

    public int? SubBrandId { get; set; }

    public int? QueryTypeMainGroupId { get; set; }

    public int? QueryTypeId { get; set; }

    public DateTime Date { get; set; }

    public int TargetTypeId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
