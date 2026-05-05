using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PdfSigneds
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? TfirmId { get; set; }

    public int BranchId { get; set; }

    public int? TbranchId { get; set; }

    public int KuserId { get; set; }

    public int? TkuserId { get; set; }

    public int? SigortaId { get; set; }

    public int? BransId { get; set; }

    public string? MusteriVknNo { get; set; }

    public string? PoliceNo { get; set; }

    public string? SigortaAdi { get; set; }

    public string? AracPlaka { get; set; }

    public string? AracRuhsatNo { get; set; }

    public string? IncomingFile { get; set; }

    public string? OutgoingFile { get; set; }

    public string? Url { get; set; }

    public DateTime CreateDate { get; set; }
}
