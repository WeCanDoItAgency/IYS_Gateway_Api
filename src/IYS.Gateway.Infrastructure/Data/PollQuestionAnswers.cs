using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PollQuestionAnswers
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public bool IsActive { get; set; }
}
