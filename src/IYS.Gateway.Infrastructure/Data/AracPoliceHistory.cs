using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracPoliceHistory
{
    public int Id { get; set; }

    public string? QueryType { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public string? Plaka { get; set; }

    public string? Ruhsat { get; set; }

    public string? SirketNo { get; set; }

    public string? YenilemeNo { get; set; }

    public string? AcenteNo { get; set; }

    public string? PoliceNo { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? TcKimlik { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? AracMarkaKodu { get; set; }

    public int? ScheduleJobId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public bool? IsSold { get; set; }

    public string? IsSoldIptalNedeni { get; set; }

    public DateTime? IsSoldIptalTarihi { get; set; }

    public bool? YeniTabloyaTasindiMi { get; set; }

    public virtual ScheduledJobs? ScheduleJob { get; set; }
}
