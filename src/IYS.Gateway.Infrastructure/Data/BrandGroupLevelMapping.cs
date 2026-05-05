using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandGroupLevelMapping
{
    public int Id { get; set; }

    public int? BrandAttributeGroupId { get; set; }

    public int? LevelId { get; set; }

    public bool IsAuth { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
