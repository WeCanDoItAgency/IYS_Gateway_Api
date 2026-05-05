using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewTrainings
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public string? Topic { get; set; }

    public string Content { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int CategoryId { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
