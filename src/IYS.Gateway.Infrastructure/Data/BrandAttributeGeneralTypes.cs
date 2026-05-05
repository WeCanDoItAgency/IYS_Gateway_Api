using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeGeneralTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Order { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
