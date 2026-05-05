using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriAraclariBakimHistory
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime BakimTarihi { get; set; }

    public Guid MusteriAraclariGuid { get; set; }
}
