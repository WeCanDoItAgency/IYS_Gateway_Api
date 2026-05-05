using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Etaleps
{
    public int Id { get; set; }

    public int QueryId { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int OdemeId { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsSend { get; set; }

    public DateTime? SendDate { get; set; }
}
