using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubBrandCompanyAssigment
{
    public int Id { get; set; }

    public Guid PaylasacakFirmGuid { get; set; }

    public int SubBrandId { get; set; }

    public int BrandId { get; set; }

    public Guid PaylasilacakFirmGuid { get; set; }

    public string SpecialProxyAddress { get; set; } = null!;

    public string SpecialProxyPort { get; set; } = null!;

    public string SpecialProxyUserName { get; set; } = null!;

    public string SpecialProxyPassword { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int PaylasilanSubBrandId { get; set; }
}
