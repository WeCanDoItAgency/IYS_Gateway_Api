using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CenterWaitingDetailNotes
{
    public int Id { get; set; }

    public string? QueryType { get; set; }

    public int? DetailId { get; set; }

    public string? Note { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? CenterRequestId { get; set; }
}
