using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCariMuhasebe
{
    public int Id { get; set; }

    public int? NewCariKartId { get; set; }

    public string? VergiNumarasi { get; set; }

    public string? TckNo { get; set; }

    public string? KepAdresi { get; set; }

    public string? TescilNumarasi { get; set; }

    public string? MersisNumarasi { get; set; }

    public string? VergiDairesi { get; set; }

    public string? MuhasebeKodu { get; set; }

    public string? AdaCode { get; set; }

    public string? PrivateCode { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public virtual NewCariKart? NewCariKart { get; set; }
}
