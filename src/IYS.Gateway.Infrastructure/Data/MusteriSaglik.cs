using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriSaglik
{
    public Guid Guid { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? NationalNumber { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public bool? IsSgk { get; set; }

    public int? ProfessionCode { get; set; }

    public bool? Renew { get; set; }

    public string? RenewPolicyNumber { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public byte? Type { get; set; }

    public bool? OncekiHastalikVarmi { get; set; }

    public string? VarsaHastalikAciklamasi { get; set; }
}
