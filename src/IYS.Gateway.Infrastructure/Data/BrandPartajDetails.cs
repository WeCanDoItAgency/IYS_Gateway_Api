using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandPartajDetails
{
    public int Id { get; set; }

    public string? TxtAgentCode { get; set; }

    public string? TxtPassword { get; set; }

    public int? BrandId { get; set; }

    public int? FirmId { get; set; }

    public string? TxtAgentUserName { get; set; }

    public string? QueryBy { get; set; }

    public string? BrowserType { get; set; }

    public bool? IsSfs { get; set; }

    public bool? SfsRedirect { get; set; }

    public bool? IsRobotProtected { get; set; }

    public bool? UseJquery { get; set; }

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

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? FrameName { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }
}
