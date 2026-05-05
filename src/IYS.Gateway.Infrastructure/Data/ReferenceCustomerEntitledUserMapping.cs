using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ReferenceCustomerEntitledUserMapping
{
    public int Id { get; set; }

    public int ReferanceCustomerCodeId { get; set; }

    public int CampaignId { get; set; }

    public int EligibleUserId { get; set; }

    public int EarnedAmount { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public bool IsActive { get; set; }

    public Guid PolicyGuid { get; set; }

    public int PolicyId { get; set; }

    public int QueryTypeId { get; set; }

    public virtual Campaigns Campaign { get; set; } = null!;

    public virtual Kullanicilar CreatedUser { get; set; } = null!;

    public virtual Kullanicilar EligibleUser { get; set; } = null!;

    public virtual ReferanceCustomerCodes ReferanceCustomerCode { get; set; } = null!;
}
