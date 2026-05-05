using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandInstallments
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string QueryType { get; set; } = null!;

    public string Card { get; set; } = null!;

    public string? CardImage { get; set; }

    public int Installment { get; set; }

    public double Comission { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
