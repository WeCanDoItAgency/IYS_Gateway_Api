using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtMahalleler
{
    public decimal KoyKodu { get; set; }

    public decimal MahalleKodu { get; set; }

    public string? MahalleAdi { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }

    public virtual UavtKoyler KoyKoduNavigation { get; set; } = null!;

    public virtual ICollection<UavtSokaklar> UavtSokaklar { get; set; } = new List<UavtSokaklar>();
}
