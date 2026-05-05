using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AutoWorkOfferSettings
{
    public int Id { get; set; }

    public string? QueryType { get; set; }

    public bool? IsActiveAutoWork { get; set; }
}
