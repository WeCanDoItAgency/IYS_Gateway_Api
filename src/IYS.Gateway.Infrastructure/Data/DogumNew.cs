using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DogumNew
{
    public long Id { get; set; }

    public string? TcKimlik { get; set; }

    public string? Il { get; set; }

    public string? DogumTarihi { get; set; }

    public DateTime? DogumTarihiDt { get; set; }
}
