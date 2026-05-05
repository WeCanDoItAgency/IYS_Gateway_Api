using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class YorumTips
{
    public int Id { get; set; }

    public string YorumTip { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
