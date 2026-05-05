using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AgreementsSigned
{
    public int Id { get; set; }

    public int AgreementId { get; set; }

    public int SignedByUser { get; set; }

    public int SignedForUser { get; set; }

    public DateTime CreatedDate { get; set; }
}
