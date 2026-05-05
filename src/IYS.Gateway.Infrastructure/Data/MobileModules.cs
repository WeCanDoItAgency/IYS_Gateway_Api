using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MobileModules
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = null!;

    public byte ModuleIndex { get; set; }

    public bool IsActive { get; set; }
}
