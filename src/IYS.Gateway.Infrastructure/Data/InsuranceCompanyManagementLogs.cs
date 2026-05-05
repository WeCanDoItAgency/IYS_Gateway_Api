using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class InsuranceCompanyManagementLogs
{
    public int Id { get; set; }

    public int SubBrandId { get; set; }

    public string? OldAgentUserName { get; set; }

    public string? OldAgentPassword { get; set; }

    public string? NewAgentUserName { get; set; }

    public string? NewAgentPassword { get; set; }

    public string? OldWsUserName { get; set; }

    public string? OldWsPassword { get; set; }

    public string? NewWsUserName { get; set; }

    public string? NewWsPassword { get; set; }

    public string? OldProductionUsername { get; set; }

    public string? OldProductionPassword { get; set; }

    public string? NewProductionUsername { get; set; }

    public string? NewProductionPassword { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? FirmId { get; set; }
}
