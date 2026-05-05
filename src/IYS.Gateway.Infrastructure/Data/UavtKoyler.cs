using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtKoyler
{
    public decimal KoyKodu { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public decimal? BucakKodu { get; set; }

    public string? KoyAdi { get; set; }

    public string? BucakAdi { get; set; }

    public string? BucakKoyAdi { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual UavtIl? IlKoduNavigation { get; set; }

    public virtual UavtIlceler? IlceKoduNavigation { get; set; }

    public virtual ICollection<UavtMahalleler> UavtMahalleler { get; set; } = new List<UavtMahalleler>();
}
