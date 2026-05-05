using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracDetay
{
    public long Id { get; set; }

    public long AracId { get; set; }

    public int FirmaId { get; set; }

    public int SubeId { get; set; }

    public int KullaniciId { get; set; }

    public int? SigortaId { get; set; }

    public int? BransId { get; set; }

    public int? OwnFirmaId { get; set; }

    public string? PoliceNo { get; set; }

    public int? TakipNo { get; set; }

    public int? IslemTipi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslama { get; set; }

    public DateTime? VadeBitis { get; set; }

    public double? BrutTutar { get; set; }

    public double? NetTutar { get; set; }

    /// <summary>
    /// acente komisyon
    /// </summary>
    public double? AkomTutar { get; set; }

    /// <summary>
    /// sube komisyon
    /// </summary>
    public double? SkomTutar { get; set; }

    public bool? IsPortal { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AracKartlar Arac { get; set; } = null!;

    public virtual NewQueryTypes? Brans { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual NewFirms? OwnFirma { get; set; }

    public virtual NewSubBrands? Sigorta { get; set; }

    public virtual Subeler Sube { get; set; } = null!;
}
