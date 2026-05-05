using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewFirmSubBrandAuth
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? QueryTypeId { get; set; }

    public int? BrandId { get; set; }

    public int? NewSubBrandId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsAuth { get; set; }

    public bool? IsWorkSecondarySystem { get; set; }

    public bool? IsWorkWebService { get; set; }

    public bool? IsSecondarySystemPayment { get; set; }

    public bool? PoliceOlusturaDusur { get; set; }
}
