using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewJobEntryAndExitProcedures
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? UserId { get; set; }

    public DateTime? StartDateOfWork { get; set; }

    public DateTime? DismissalDate { get; set; }

    public DateTime? SgkreleaseDate { get; set; }

    public string? Description { get; set; }

    public bool? IsActiveWorker { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
