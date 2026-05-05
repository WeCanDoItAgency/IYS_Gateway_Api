using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ActionQuestion
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public string QueryType { get; set; } = null!;

    public int Location { get; set; }

    public string Question { get; set; } = null!;

    public int AnswerType { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<ActionAnswers> ActionAnswers { get; set; } = new List<ActionAnswers>();
}
