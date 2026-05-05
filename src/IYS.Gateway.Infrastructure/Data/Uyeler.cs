using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Uyeler
{
    public int Id { get; set; }

    public int? MerkezId { get; set; }

    public int? SubeId { get; set; }

    public int? AltSubeId { get; set; }

    public int? AltSubePersonelId { get; set; }

    public int? KatId { get; set; }

    public int? AltKatId { get; set; }
}
