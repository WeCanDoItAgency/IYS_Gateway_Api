using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class YasAralik
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public int Baslama { get; set; }

    public int Bitis { get; set; }

    public double Tutar { get; set; }
}
