using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumlar
{
    public int Id { get; set; }

    public string? FirmaAdi { get; set; }

    public string? FirmaAdres { get; set; }

    public string? FirmaTelefon { get; set; }

    public string? FirmaAnlasma { get; set; }

    public string? FirmaPoliceTip { get; set; }

    public string? FirmaIl { get; set; }

    public string? FirmaIlce { get; set; }

    public int? FirmaKurumTipiId { get; set; }

    public string? FirmaUrunTipi { get; set; }

    public string? FirmaKurumTipi { get; set; }

    public string? FirmaNetworkTipi { get; set; }

    public string? KurumAdi { get; set; }

    public string? KurumNotu { get; set; }

    public string? KonumX { get; set; }

    public string? KonumY { get; set; }

    public string? TelefonNo { get; set; }

    public string? BrandCode { get; set; }

    public string? BrandName { get; set; }

    public string? ServiceTypeName { get; set; }

    public int? UsageType { get; set; }

    public int? FirmId { get; set; }

    public int? FirmCode { get; set; }

    public string? QueryType { get; set; }

    public string? FirmaEmail { get; set; }

    public int? CityCode { get; set; }

    public int? CountyCode { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public bool? IsActive { get; set; }

    public double? AvgPoint { get; set; }

    public virtual ICollection<AnlasmaliKurumUserFavs> AnlasmaliKurumUserFavs { get; set; } = new List<AnlasmaliKurumUserFavs>();

    public virtual ICollection<AnlasmaliServislerDirectionLog> AnlasmaliServislerDirectionLog { get; set; } = new List<AnlasmaliServislerDirectionLog>();
}
