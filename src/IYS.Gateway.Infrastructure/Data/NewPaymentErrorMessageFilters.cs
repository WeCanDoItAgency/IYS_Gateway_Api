using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewPaymentErrorMessageFilters
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int QueryTypeId { get; set; }

    public int Action { get; set; }

    public string IncomingErrorMessage { get; set; } = null!;

    public string ShowErrorMessage { get; set; } = null!;

    public bool ShowCallCenter { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool IsActive { get; set; }

    public bool? IsSendPolicy { get; set; }

    public int? FirmId { get; set; }

    public bool? IsSecondarySystemPayment { get; set; }
}
