using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimSilmeIslemleri
{
    public int Id { get; set; }

    public int? SubBrandId { get; set; }

    public bool? IncludeProductionDelete { get; set; }

    public bool? IsDublicate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
