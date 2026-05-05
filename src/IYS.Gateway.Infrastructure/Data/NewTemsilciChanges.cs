using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewTemsilciChanges
{
    public int Id { get; set; }

    public int? TemsilciId { get; set; }

    public int? SubeId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
