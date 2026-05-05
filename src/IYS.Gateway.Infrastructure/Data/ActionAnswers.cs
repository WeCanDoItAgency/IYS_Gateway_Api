using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ActionAnswers
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public string? AnswerText { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ActionQuestion? Question { get; set; }
}
