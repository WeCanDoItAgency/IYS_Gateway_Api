using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimSahalar
{
    public int Id { get; set; }

    public int QueryId { get; set; }

    public string? Sirkod { get; set; }

    public string? Brnkod { get; set; }

    public string? Brnadi { get; set; }

    public string? Musaditam { get; set; }

    public DateTime? Tanzim { get; set; }

    public string? Policeno { get; set; }

    public double? Brutprim { get; set; }

    public string? Siguzunad2 { get; set; }

    public string? Tckimlik { get; set; }

    public string? Sigvergino { get; set; }

    public string? Sonplaka { get; set; }

    public DateTime? Bitis { get; set; }

    public string? Sigettiren { get; set; }

    public string? Sigkisaad { get; set; }

    public string? Musheskod { get; set; }

    public string? InputData { get; set; }

    public bool IsClosed { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? OwnfirmId { get; set; }

    public int? TakipId { get; set; }

    public int? DetayId { get; set; }

    public int? UstSubeId { get; set; }

    public int? MerkezId { get; set; }

    public DateTime? ClosedDate { get; set; }

    public double? Netprim { get; set; }

    public string? Sasino { get; set; }

    public string? Zeyilno { get; set; }

    public string? Tecditno { get; set; }
}
