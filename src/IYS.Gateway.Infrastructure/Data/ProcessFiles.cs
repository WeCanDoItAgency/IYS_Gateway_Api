using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ProcessFiles
{
    public int Id { get; set; }

    public int ProcessId { get; set; }

    public int TypeId { get; set; }

    public int FtypeId { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public string? IncomingFile { get; set; }

    public string? FilePath { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }
}
