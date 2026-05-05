using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferSktReferenceLogs
{
    public int Id { get; set; }

    public string QueryType { get; set; } = null!;

    public Guid HeaderGuid { get; set; }

    public int ReferencedSktId { get; set; }

    public string ReferencedCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }
}
