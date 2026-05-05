using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriCepleri
{
    public Guid Guid { get; set; }

    public string? CepMarka { get; set; }

    public int? CepMarkaId { get; set; }

    public string? CepModel { get; set; }

    public int? CepModelId { get; set; }

    public string? ImeiNo { get; set; }

    public string? NationalNumber { get; set; }

    public string? Phone { get; set; }

    public bool? IsActive { get; set; }

    public int? UserId { get; set; }

    public byte? Type { get; set; }
}
