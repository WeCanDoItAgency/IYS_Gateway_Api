using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MobilePhoneModels
{
    public int Id { get; set; }

    public int? MarkId { get; set; }

    public string? ModelName { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedCreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual MobilePhoneMarks? Mark { get; set; }
}
