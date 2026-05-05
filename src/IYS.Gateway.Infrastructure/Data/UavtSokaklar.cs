using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtSokaklar
{
    public decimal Csbmkodu { get; set; }

    public decimal? CsbmmahalleKodu { get; set; }

    public int? Csbmtipi { get; set; }

    public string? Csbmadi { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }

    public virtual UavtMahalleler? CsbmmahalleKoduNavigation { get; set; }
}
