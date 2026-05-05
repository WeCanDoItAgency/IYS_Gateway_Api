using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GeneralLogs
{
    public int Id { get; set; }

    public int? RequestId { get; set; }

    public string? RequestGuid { get; set; }

    public string? ApiName { get; set; }

    public string? QueryType { get; set; }

    public string? RequestFile { get; set; }

    public string? ResponseFile { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }

    public DateTime? ResponseDate { get; set; }

    public string? NationalNumber { get; set; }

    public string? PlateNumber { get; set; }

    public string? PassaportNumber { get; set; }

    public string? PermitNumber { get; set; }

    public bool? IsError200 { get; set; }

    public bool? IsError101 { get; set; }

    public bool? IsError102 { get; set; }

    public bool? IsError103 { get; set; }

    public bool? IsError104 { get; set; }

    public bool? IsError105 { get; set; }

    public bool? IsError106 { get; set; }

    public bool? IsError107 { get; set; }

    public bool? IsError108 { get; set; }

    public bool? IsError109 { get; set; }

    public bool? IsError110 { get; set; }

    public bool? IsError111 { get; set; }

    public bool? IsError100 { get; set; }

    public bool? IsError365 { get; set; }

    public bool? IsError1001 { get; set; }

    public bool? IsError1002 { get; set; }

    public bool? IsError1003 { get; set; }

    public bool? IsError1004 { get; set; }

    public bool? IsError1005 { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsError503 { get; set; }

    public bool? IsError504 { get; set; }

    public bool? IsError505 { get; set; }

    public bool? IsError500 { get; set; }

    public int? AgentId { get; set; }

    public bool? IsError1500 { get; set; }

    public bool? IsError112 { get; set; }

    public bool? IsError113 { get; set; }

    public bool? IsError114 { get; set; }

    public bool? IsError115 { get; set; }

    public bool? IsError116 { get; set; }
}
