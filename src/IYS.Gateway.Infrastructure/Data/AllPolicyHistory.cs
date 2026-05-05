using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AllPolicyHistory
{
    public int Id { get; set; }

    public string QueryType { get; set; } = null!;

    public DateTime? PoliceBaslangic { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public string? Plaka { get; set; }

    public string? Ruhsat { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public string? AracMarkaKodu { get; set; }

    public string? SirketKodu { get; set; }

    public string? YenilemeNo { get; set; }

    public string? AcenteNo { get; set; }

    public string PoliceNo { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? KimlikNo { get; set; }

    public string? UavtKodu { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public int? ScheduleJobId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsSold { get; set; }

    public string? IsSoldIptalNedeni { get; set; }

    public DateTime? IsSoldIptalTarihi { get; set; }
}
