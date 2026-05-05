using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EmailTemplates
{
    public int Id { get; set; }

    public string? MessageTemplate { get; set; }

    public int TemplateType { get; set; }

    public string QueueName { get; set; } = null!;
}
