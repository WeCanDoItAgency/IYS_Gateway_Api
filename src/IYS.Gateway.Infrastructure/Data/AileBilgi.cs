using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AileBilgi
{
    public int Id { get; set; }

    public int BaslikId { get; set; }

    public string QueryType { get; set; } = null!;

    public string VknNo { get; set; } = null!;

    public string? Yakinlik { get; set; }

    public string? Boy { get; set; }

    public string? Kilo { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime CreateDate { get; set; }

    public int KuserId { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
