using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtIlBeldeYs
{
    public int Id { get; set; }

    public int? IlKodu { get; set; }

    public string? Adi { get; set; }

    public string? DogaBeldekodu { get; set; }

    public string? AkBeldekodu { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
