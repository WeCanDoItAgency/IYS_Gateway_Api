using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmswidgetItemMappings
{
    public int Id { get; set; }

    public int WidgetId { get; set; }

    public int ItemId { get; set; }

    public int LanguageId { get; set; }

    public virtual AcenteOnlineCmswidgetsItem Item { get; set; } = null!;

    public virtual AcenteOnlineCmswidgets Widget { get; set; } = null!;
}
