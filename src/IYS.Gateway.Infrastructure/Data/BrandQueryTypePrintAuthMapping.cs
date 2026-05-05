using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandQueryTypePrintAuthMapping
{
    public int Id { get; set; }

    public int QueryTypeId { get; set; }

    public int BrandId { get; set; }

    public bool OfferPrint { get; set; }

    public bool PolicyPrint { get; set; }

    public bool ReceiptPrint { get; set; }

    public bool CertificatePrint { get; set; }

    public bool Turkish { get; set; }

    public bool English { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? WorkFromBot { get; set; }
}
