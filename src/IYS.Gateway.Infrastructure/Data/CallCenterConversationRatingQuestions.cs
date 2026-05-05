using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterConversationRatingQuestions
{
    public int Id { get; set; }

    public string? RatingQuestion { get; set; }

    public int? MaxScore { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<CallCenterConversationRatingLogs> CallCenterConversationRatingLogs { get; set; } = new List<CallCenterConversationRatingLogs>();
}
