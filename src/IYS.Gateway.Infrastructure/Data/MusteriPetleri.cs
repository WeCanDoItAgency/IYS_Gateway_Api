using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriPetleri
{
    public Guid Guid { get; set; }

    public bool? Chipped { get; set; }

    public string? ColorCode { get; set; }

    public DateTime? PetBirthdate { get; set; }

    public string? NationalNumber { get; set; }

    public string? PetName { get; set; }

    public int? PetRace { get; set; }

    public byte? PetType { get; set; }

    public string? Sex { get; set; }

    public bool? IsActive { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Type { get; set; }
}
