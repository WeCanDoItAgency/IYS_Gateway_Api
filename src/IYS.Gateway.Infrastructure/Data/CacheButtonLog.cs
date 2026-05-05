using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CacheButtonLog
{
    public int Id { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }

    public int? Type { get; set; }
}
