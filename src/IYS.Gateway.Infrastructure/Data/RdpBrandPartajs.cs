using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public int? BrandId { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? AgentCode { get; set; }

    public string? AgentUsername { get; set; }

    public string? AgentPassword { get; set; }

    public string? WebLink { get; set; }

    public string? TxtAgentCode { get; set; }

    public string? TxtUsername { get; set; }

    public string? TxtPassword { get; set; }

    public string? BtnClick { get; set; }

    public bool? IsFrame { get; set; }

    public bool? IsCollection { get; set; }

    public string? IpAddress { get; set; }

    public string? MainUrl { get; set; }

    public string? FormId { get; set; }

    public string? IconUrl { get; set; }

    public string? FontColor { get; set; }

    public string? Background { get; set; }

    public string? CaptchaId { get; set; }

    public string? CaptchaPicture { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? BrowserType { get; set; }

    public bool? IsSfs { get; set; }

    public string? FrameName { get; set; }

    public bool? SfsRedirect { get; set; }

    public bool? ProxyRequired { get; set; }

    public bool? IsRobotProtected { get; set; }

    public bool? UseJquery { get; set; }

    public string? QueryBy { get; set; }

    public string? Mfcode { get; set; }

    public string? Mfasecret { get; set; }

    public string? SmsSelector { get; set; }

    public bool IsSelfUser { get; set; }

    public string? SecondarySystemUserName { get; set; }

    public string? SecondarySystemPassword { get; set; }

    public string? SecondarySystemOtpcode { get; set; }

    public string? SecondarySystemSmsUrl { get; set; }

    public bool? SecondarySystemUseOwnInfo { get; set; }

    public string? SecondarySystemRecaptchaCode { get; set; }

    public string? SecondarySystemRecaptchaCallback { get; set; }

    public string? ProxyAddress { get; set; }

    public string? ProxyPort { get; set; }

    public string? ProxyUsername { get; set; }

    public string? ProxyPassword { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsCenter { get; set; }

    public bool? IsActive { get; set; }

    public int? ParentPartajId { get; set; }

    public int? RobotRunType { get; set; }

    public int? SmsqrId { get; set; }

    public string? OwnProxyAddress { get; set; }

    public string? OwnProxyPort { get; set; }

    public string? OwnProxyUser { get; set; }

    public string? OwnProxyPassword { get; set; }

    public bool? IsUseOwnProxySettings { get; set; }

    public virtual NewBrands? Brand { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<RdpPartajBranchAuths> RdpPartajBranchAuths { get; set; } = new List<RdpPartajBranchAuths>();

    public virtual ICollection<RdpPartajUserAuths> RdpPartajUserAuths { get; set; } = new List<RdpPartajUserAuths>();

    public virtual SmsbotQrSs? Smsqr { get; set; }
}
