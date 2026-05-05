using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Feedbacks
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public string? Title { get; set; }

    public string? Subject { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public string? Source { get; set; }

    public string? Url { get; set; }

    public string? FilePath { get; set; }

    public bool? IsActive { get; set; }

    public int? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual Subeler? Branch { get; set; }
}
