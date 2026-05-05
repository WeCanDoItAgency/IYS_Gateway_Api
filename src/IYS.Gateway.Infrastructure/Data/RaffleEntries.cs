using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RaffleEntries
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string IdentityNumber { get; set; } = null!;

    public int Entries { get; set; }

    public DateTime CreateDate { get; set; }

    public int Type { get; set; }

    public int? PaymentId { get; set; }

    public int? DetailId { get; set; }

    public int? HeaderId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int RaffleId { get; set; }

    public string Querytype { get; set; } = null!;
}
