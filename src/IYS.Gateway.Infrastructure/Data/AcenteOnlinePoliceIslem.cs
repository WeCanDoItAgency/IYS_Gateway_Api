using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlinePoliceIslem
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public int? FirmaId { get; set; }

    public string? PoliceTipi { get; set; }

    public DateTime? PoliceVadeTarihi { get; set; }

    public string? PoliceAciklama { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateUser { get; set; }

    public bool? IsActive { get; set; }
}
