using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CommonPoliceHistory
{
    public int Id { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public string? Plaka { get; set; }

    public string? Ruhsat { get; set; }

    public string? UavtNo { get; set; }

    public string? TcKimlik { get; set; }

    public string? SirketNo { get; set; }

    public string? YenilemeNo { get; set; }

    public string? AcenteNo { get; set; }

    public string? PoliceNo { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public int ScheduleJobId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Notes { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
