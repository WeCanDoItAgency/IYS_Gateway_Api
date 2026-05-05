using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewGeneralNotes
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? ConnectedRecordId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
