using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCariIletisim
{
    public int Id { get; set; }

    public int NewCariKartId { get; set; }

    public string? CepTelefon { get; set; }

    public string? Email { get; set; }

    public int? MeslekKodu { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool IsActive { get; set; }
}
