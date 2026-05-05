using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PollQuestions
{
    public int Id { get; set; }

    public int PollId { get; set; }

    public string Question { get; set; } = null!;

    public bool IsActive { get; set; }
}
