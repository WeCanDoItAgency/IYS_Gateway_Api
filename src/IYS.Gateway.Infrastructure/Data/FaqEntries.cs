using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FaqEntries
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public string? Question { get; set; }

    public string? AnswerHtml { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }
}
