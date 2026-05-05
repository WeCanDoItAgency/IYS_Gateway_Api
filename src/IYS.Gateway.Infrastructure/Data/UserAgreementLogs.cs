using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserAgreementLogs
{
    public int Id { get; set; }

    public int? NewCariKartId { get; set; }

    public int UserId { get; set; }

    public int EntityId { get; set; }

    public string? NationalNumber { get; set; }

    public string? PassportNumber { get; set; }

    public short AgreementType { get; set; }

    public string QueryType { get; set; } = null!;

    public string Ipaddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? ProfessionCode { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? MongoControl { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public virtual NewCariKart? NewCariKart { get; set; }
}
