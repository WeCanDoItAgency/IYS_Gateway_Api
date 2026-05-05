using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterConversationRatingLogs
{
    public int Id { get; set; }

    public int CallCenterConversationRatingQuestionsId { get; set; }

    public int? RatedUserId { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public int? ExpertiseRequestStatusLogId { get; set; }

    public int? RatedScore { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual CallCenterConversationRatingQuestions CallCenterConversationRatingQuestions { get; set; } = null!;
}
