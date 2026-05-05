using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferFirmCreditCardInfoNotes
{
    public int Id { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public Guid? PolicyGuid { get; set; }

    public string? CenterWaitingMongoId { get; set; }

    public int? FirmCreditCardInfoId { get; set; }

    public string? Note { get; set; }

    public int? FirmId { get; set; }

    public int? ManuelOperationsId { get; set; }
}
