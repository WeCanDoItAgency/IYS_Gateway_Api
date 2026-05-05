using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserWhatsAppSmsQrAuth
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int WhatsAppSmsQrId { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
