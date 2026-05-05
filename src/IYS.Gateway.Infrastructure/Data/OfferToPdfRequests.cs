using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferToPdfRequests
{
    public int Id { get; set; }

    public Guid? HeaderGuid { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? QueryType { get; set; }

    public string? Path { get; set; }

    public byte? Type { get; set; }

    public bool IsHaveDetail { get; set; }

    public virtual ICollection<OfferToPdfRequestsDetails> OfferToPdfRequestsDetails { get; set; } = new List<OfferToPdfRequestsDetails>();
}
