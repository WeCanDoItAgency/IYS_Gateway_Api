using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineAgreements
{
    public int Id { get; set; }

    public string? IpAdress { get; set; }

    public string? NatioanlNulbar { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public string? AgreementType { get; set; }

    public string? AgreementText { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? FirmaId { get; set; }

    public int? CreateUserId { get; set; }

    public bool? IsActive { get; set; }
}
