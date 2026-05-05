using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GuidEncryptedIdRelations
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public string EncryptedHeaderId { get; set; } = null!;

    public string QueryType { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int ClickCount { get; set; }
}
