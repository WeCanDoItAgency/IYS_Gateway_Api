using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewJobOfferNominees
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? SubeId { get; set; }

    public int JobOfferId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Tcno { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int? MaritalStatusId { get; set; }

    public int CountryId { get; set; }

    public int StatusId { get; set; }

    public int? Points { get; set; }

    public string? Description { get; set; }

    public string? LinkedinAddress { get; set; }

    public string? SkypeAddress { get; set; }

    public string? Address { get; set; }

    public int? UniversityId { get; set; }

    public string? SchoolInformation { get; set; }

    public bool? IsArmyDone { get; set; }

    public int? WorkExperienceYear { get; set; }

    public bool? IsKvkkdone { get; set; }

    public string? Abilities { get; set; }

    public string? Cvpath { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
