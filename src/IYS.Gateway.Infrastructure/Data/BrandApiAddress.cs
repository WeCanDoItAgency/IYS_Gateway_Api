using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandApiAddress
{
    public int Id { get; set; }

    public int AddressCategory { get; set; }

    public int AddressType { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int BrandId { get; set; }

    public string? Url { get; set; }

    public virtual NewBrands Brand { get; set; } = null!;
}
