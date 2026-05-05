using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmswidgetsItem
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public string? Image { get; set; }

    public int Pid { get; set; }

    public int SiteId { get; set; }

    public int Order { get; set; }

    public virtual ICollection<AcenteOnlineCmswidgetItemMappings> AcenteOnlineCmswidgetItemMappings { get; set; } = new List<AcenteOnlineCmswidgetItemMappings>();
}
