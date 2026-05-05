using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCariAddress
{
    public int Id { get; set; }

    public int NewCariKartId { get; set; }

    public int? UlkeKodu { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public int? KoySemtKodu { get; set; }

    public int? MahalleKodu { get; set; }

    public int? SokakKodu { get; set; }

    public int? DaskBeldeKodu { get; set; }

    public string? BinaNo { get; set; }

    public int? BeldeKodu { get; set; }

    public string? IlAdi { get; set; }

    public string? IlceAdi { get; set; }

    public string? KoySemtAdi { get; set; }

    public string? MahalleAdi { get; set; }

    public string? SokakAdi { get; set; }

    public string? KapiNo { get; set; }

    public string? DaireNo { get; set; }

    public string? UavtKodu { get; set; }

    public int? PostaKodu { get; set; }

    public string? Ada { get; set; }

    public string? Pafta { get; set; }

    public string? Parsel { get; set; }

    public string? Bolum { get; set; }

    public string? SayfaNo { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public virtual NewCariKart NewCariKart { get; set; } = null!;
}
