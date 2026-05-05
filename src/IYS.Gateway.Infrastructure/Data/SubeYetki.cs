using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubeYetki
{
    public int Id { get; set; }

    public int SubeId { get; set; }

    public int BransId { get; set; }

    public int SigortaId { get; set; }

    public bool? IsAuth { get; set; }

    public bool? IsSendcenter { get; set; }

    public bool? IsSendcallcenter { get; set; }

    public bool? IsCallwelcome { get; set; }

    public bool? IsOpenPay { get; set; }

    public bool? IsSendbot { get; set; }

    public bool? IsSendbotManuel { get; set; }

    public bool? IsSendcenterManuel { get; set; }

    public bool? IsSendcenterManuelFiyatli { get; set; }

    public bool IsSendcenterTekrarsor { get; set; }

    public bool IsSendcenterEkopre { get; set; }

    public bool IsDiscountRequest { get; set; }

    public bool IsAuthorizationRequest { get; set; }

    public bool IsAdditionalPremiumDiscount { get; set; }

    public bool Is3dpayment { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? Is3dPaymentForSubBrand { get; set; }

    public bool? IsWebService { get; set; }

    public virtual NewQueryTypes Brans { get; set; } = null!;

    public virtual NewSubBrands Sigorta { get; set; } = null!;

    public virtual Subeler Sube { get; set; } = null!;
}
