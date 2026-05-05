using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtIlceler
{
    public int IlceKodu { get; set; }

    public int? IlKodu { get; set; }

    public string? Adi { get; set; }

    public string? PostaKodu { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }

    public virtual ICollection<UavtKoyler> UavtKoyler { get; set; } = new List<UavtKoyler>();
}
