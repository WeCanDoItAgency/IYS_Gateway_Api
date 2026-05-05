using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EgmKullanimTarziKarsilastirmaListesi
{
    public int Id { get; set; }

    public string? KullanimTarziAdi { get; set; }

    public int? UstTipKodu { get; set; }

    public int? AltTipKodu { get; set; }

    public string? UstTipAdi { get; set; }

    public string? AltTipAdi { get; set; }

    public int ListKey { get; set; }

    public int? GroupId { get; set; }

    public bool? FetchedFromEgm { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
