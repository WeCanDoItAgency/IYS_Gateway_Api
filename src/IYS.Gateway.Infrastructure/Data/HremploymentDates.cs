using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class HremploymentDates
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? UserId { get; set; }

    public DateTime? JobStartDate { get; set; }

    public DateTime? JobEndDate { get; set; }

    public DateTime? SgkstartDate { get; set; }

    public DateTime? SgkendDate { get; set; }

    public bool? IsActiveStaff { get; set; }

    public string? Description { get; set; }

    public int? CreateUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
