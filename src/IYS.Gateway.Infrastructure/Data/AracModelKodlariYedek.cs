using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracModelKodlariYedek
{
    public int Id { get; set; }

    public int ModelYear { get; set; }

    public int Spid { get; set; }

    public string? ModelKodu { get; set; }

    public string? ModelAdi { get; set; }

    public double? Bedel { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
