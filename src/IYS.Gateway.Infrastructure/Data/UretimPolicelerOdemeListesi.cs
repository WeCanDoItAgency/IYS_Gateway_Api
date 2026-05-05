using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimPolicelerOdemeListesi
{
    public int Id { get; set; }

    public int? UretimPoliceId { get; set; }

    public DateTime? VadeTarihi { get; set; }

    public string? TaksitSayisi { get; set; }

    public string? TaksitSirasi { get; set; }

    public double? Tutar { get; set; }

    public DateTime? CreateDate { get; set; }
}
