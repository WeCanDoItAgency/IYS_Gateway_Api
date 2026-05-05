using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumTipleri
{
    public int Id { get; set; }

    public string? FirmaKurumTipi { get; set; }

    public int? GrupTipi { get; set; }

    public string? ImagePath { get; set; }

    public bool? IsActive { get; set; }

    public virtual AnlasmaliKurumAnaTipleri? GrupTipiNavigation { get; set; }
}
