using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ChangedPolicyOwnerLog
{
    public int Id { get; set; }

    public int QueryTypeId { get; set; }

    public string QueryType { get; set; } = null!;

    public int EntityId { get; set; }

    public int? FromPlaceId { get; set; }

    public int? EskiCalisilanSktid { get; set; }

    public int? EskiCalisilanUserId { get; set; }

    public int? EskiCalisilanSktKomisyonId { get; set; }

    public double? EskiCalisilanSktKomisyon { get; set; }

    public int? YeniIslemSahibiSktid { get; set; }

    public int? YeniIslemSahibiUserId { get; set; }

    public int? YeniIslemSahibiSktKomisyonId { get; set; }

    public double? YeniIslemSahibiSktKomisyon { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }
}
