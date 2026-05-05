using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmswidgets
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Pid { get; set; }

    public int Siteid { get; set; }

    public string? LocationSlug { get; set; }

    public string? WidgetLocation { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<AcenteOnlineCmswidgetItemMappings> AcenteOnlineCmswidgetItemMappings { get; set; } = new List<AcenteOnlineCmswidgetItemMappings>();
}
