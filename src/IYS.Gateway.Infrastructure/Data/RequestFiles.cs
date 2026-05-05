using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RequestFiles
{
    public int Id { get; set; }

    public long? RequestId { get; set; }

    public string? FilePath { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }

    public int? UserId { get; set; }
}
