using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FeedBackCategories
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
