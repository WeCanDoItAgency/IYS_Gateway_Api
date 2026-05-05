using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewContacts
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? NewCariKartId { get; set; }

    public int? BankAccountId { get; set; }

    public int? BrandId { get; set; }

    public int? DepartmentId { get; set; }

    public string? Gender { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public DateTime? Birthday { get; set; }

    public string? SpecialNote { get; set; }

    public string? ProfessionCode { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public bool? Cc { get; set; }

    public bool? Bcc { get; set; }

    public bool? To { get; set; }

    public string? Email { get; set; }

    public string? BirthPlace { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Religion { get; set; }

    public string? BloodType { get; set; }

    public int? GroupType { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public virtual NewCariKart? NewCariKart { get; set; }
}
