using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AddressRequestResponsesLog
{
    public long Id { get; set; }

    public short RequestFirm { get; set; }

    public int? UserId { get; set; }

    public string NationalNumber { get; set; } = null!;

    public short RequestType { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LatestUpdate { get; set; }

    public short Status { get; set; }

    public string? NameSurname { get; set; }

    public string? City { get; set; }

    public string? County { get; set; }

    public string? District { get; set; }

    public string? Street { get; set; }

    public string? Apartment { get; set; }

    public string? ApartmentNo { get; set; }

    public string? FlatNo { get; set; }

    public string? Neighborhood { get; set; }

    public string? Birthday { get; set; }

    public string? Sex { get; set; }

    public string? Ipaddress { get; set; }

    public string? QueryType { get; set; }

    public string? Browser { get; set; }

    public string? Source { get; set; }

    public string? AccessTokenToken { get; set; }

    public DateTime? BirthDate { get; set; }
}
