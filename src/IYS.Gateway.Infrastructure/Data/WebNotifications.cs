using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class WebNotifications
{
    public int Id { get; set; }

    public int? Type { get; set; }

    public string? Title { get; set; }

    public string? ContentDetail { get; set; }

    public bool? IsToast { get; set; }

    public bool? IsSendSms { get; set; }

    public bool? IsSendMail { get; set; }

    public bool? IsSliding { get; set; }

    public bool? IsReminder { get; set; }

    public int? BranchTypeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? ReminderDatetime { get; set; }

    public int? ReceiverFirmId { get; set; }

    public int? ReceiverBranchId { get; set; }

    public int? ReceiverUserId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? CariCardId { get; set; }

    public bool? IsSendedMail { get; set; }

    public bool? IsSendedSms { get; set; }

    public virtual BranchTypes? BranchType { get; set; }

    public virtual Subeler? ReceiverBranch { get; set; }

    public virtual NewFirms? ReceiverFirm { get; set; }

    public virtual Kullanicilar? ReceiverUser { get; set; }
}
