using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Branches
{
    public int Id { get; set; }

    public string BranchName { get; set; } = null!;

    public string BranchAddress { get; set; } = null!;

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Gsm { get; set; }

    public string? ResponsiblePerson { get; set; }

    public string? Lat { get; set; }

    public string? Lon { get; set; }

    public bool IsInTurkey { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public bool? IsActive { get; set; }
}
