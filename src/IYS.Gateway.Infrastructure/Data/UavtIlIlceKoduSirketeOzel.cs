using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtIlIlceKoduSirketeOzel
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int? IlceKodu { get; set; }

    public string? IlceAdiCustom { get; set; }

    public int? IlKodu { get; set; }

    public string? IlAdiCustom { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? IlceKoduCustom { get; set; }

    public int? IllKoduCustom { get; set; }
}
