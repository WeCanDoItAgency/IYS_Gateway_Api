using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ProductionPeriodClosure
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public DateTime Date1 { get; set; }

    public DateTime Date2 { get; set; }

    public bool Status { get; set; }

    public bool? AccountancyStatus { get; set; }

    public DateTime? AccountancyStatusDate { get; set; }

    public int? AccountancyUser { get; set; }

    public bool? InfoIsSendMail { get; set; }

    public DateTime? InfoIsSendMailDate { get; set; }

    public int? InfoIsSendMailUser { get; set; }

    public bool? AccIsSendMail { get; set; }

    public DateTime? AccIsSendMailDate { get; set; }

    public int? AccIsSendMailUser { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public int MailSendLastDays { get; set; }
}
