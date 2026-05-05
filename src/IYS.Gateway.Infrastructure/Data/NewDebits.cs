using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewDebits
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int UserId { get; set; }

    public string? DocumentNo { get; set; }

    public DateTime Date { get; set; }

    public int? ReturnStatusId { get; set; }

    public string? Description { get; set; }

    public bool? IsPhoneEnabled { get; set; }

    public string? Phone { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsReceived { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public int? ReceivedUserId { get; set; }
}
