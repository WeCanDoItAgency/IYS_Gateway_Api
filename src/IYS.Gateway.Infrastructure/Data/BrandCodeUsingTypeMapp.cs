using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandCodeUsingTypeMapp
{
    public int Id { get; set; }

    public string? BrandCodeFull { get; set; }

    public int? InsuranceBrandId { get; set; }

    public string? UsingType { get; set; }

    public string? TariffCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
