using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ActionAnswersLog
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int Location { get; set; }

    public int QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public int? AnswerType { get; set; }

    public string AnswerText { get; set; } = null!;

    public string? QuestionText { get; set; }

    public Guid? DetailGuid { get; set; }

    public Guid? HeaderGuid { get; set; }

    public string? QueryType { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }
}
