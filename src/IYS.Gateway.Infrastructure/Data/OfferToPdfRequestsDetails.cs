using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferToPdfRequestsDetails
{
    public int Id { get; set; }

    public int OfferRequestPdfId { get; set; }

    public Guid DetailGuid { get; set; }

    public virtual OfferToPdfRequests OfferRequestPdf { get; set; } = null!;
}
