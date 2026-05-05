using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Payment3Dresponses
{
    public int Id { get; set; }

    public int? Payment3DrequestId { get; set; }

    public bool? Status { get; set; }

    public string? ResponseText { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public string? MsuSessionToken { get; set; }

    public string? RawResponse { get; set; }
}
