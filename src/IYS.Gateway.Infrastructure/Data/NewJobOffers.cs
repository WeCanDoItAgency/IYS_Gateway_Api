using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewJobOffers
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public string JobTitle { get; set; } = null!;

    public DateTime Date { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
