using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ScheduleJobPolicyHistoryLog
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? AracPlaka { get; set; }

    public string? Ruhsat { get; set; }

    public string? KimlikNo { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public bool? PolicesiVarMi { get; set; }

    public bool? BizdenMi { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public string? AcenteKodu { get; set; }

    public string? FirmaKodu { get; set; }

    public string? FirmaAdi { get; set; }

    public string? PoliceNumarasi { get; set; }

    public string? UavtKodu { get; set; }

    public string? QueryType { get; set; }

    public int? PoliceYili { get; set; }

    public DateOnly? CreateDate { get; set; }
}
