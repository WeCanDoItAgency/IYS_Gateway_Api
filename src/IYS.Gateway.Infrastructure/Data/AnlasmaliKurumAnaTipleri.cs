using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumAnaTipleri
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ImagePath { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AnlasmaliKurumTipleri> AnlasmaliKurumTipleri { get; set; } = new List<AnlasmaliKurumTipleri>();
}
