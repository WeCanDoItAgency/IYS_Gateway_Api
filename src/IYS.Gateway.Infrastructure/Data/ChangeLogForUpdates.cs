using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ChangeLogForUpdates
{
    public int Id { get; set; }

    public string TableName { get; set; } = null!;

    public int OperationId { get; set; }

    public DateTime CreateDate { get; set; }

    public int UserId { get; set; }
}
