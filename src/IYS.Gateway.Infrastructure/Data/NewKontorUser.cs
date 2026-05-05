using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewKontorUser
{
    public int Id { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int PaymentId { get; set; }

    public int SubBrandId { get; set; }

    public double Kullanilan { get; set; }

    public int FirmId { get; set; }

    public int? SktId { get; set; }

    public int UserId { get; set; }

    public string QueryType { get; set; } = null!;

    public double Yuklenen { get; set; }

    public int YukleyenSubeid { get; set; }

    public int YukleyenUserid { get; set; }

    public int? KurTipi { get; set; }

    public double? KurTutar { get; set; }

    public double? YuklenenDovizTutar { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public int? CommissionType { get; set; }

    public int? CommissionId { get; set; }
}
