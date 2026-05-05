using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ErrMail
{
    public int Id { get; set; }

    public string? Firma { get; set; }

    public int? Kid { get; set; }

    public string? Yetkili { get; set; }

    public string? Yetkilimail { get; set; }
}
