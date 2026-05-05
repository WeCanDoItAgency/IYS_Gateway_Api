using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Notifications
{
    public int Id { get; set; }

    public string? Topic { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public int? PushType { get; set; }

    public int? ContentId { get; set; }

    public string? MessageId { get; set; }

    public int? ToUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
