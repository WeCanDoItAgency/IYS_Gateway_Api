using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MobilePhoneMarks
{
    public int Id { get; set; }

    public string? MarkName { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedCreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<MobilePhoneModels> MobilePhoneModels { get; set; } = new List<MobilePhoneModels>();
}
