using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandWebLinks
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public int? BrandId { get; set; }

    public bool? IsActive { get; set; }

    public string? QueryBy { get; set; }

    public string? BrowserType { get; set; }

    public bool? IsSfs { get; set; }

    public bool? SfsRedirect { get; set; }

    public bool? IsRobotProtected { get; set; }

    public bool? IsFrame { get; set; }

    public bool? UseJquery { get; set; }

    public string? BtnClick { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsCollection { get; set; }

    public string? MainUrl { get; set; }

    public string? FormId { get; set; }

    public string? IconUrl { get; set; }

    public string? FontColor { get; set; }

    public string? Background { get; set; }

    public string? CaptchaId { get; set; }

    public string? CaptchaPicture { get; set; }

    public string? FrameName { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public int? RobotRunType { get; set; }

    public bool? IsMainUrl { get; set; }

    public virtual ICollection<RdpBrandPartajsBrandWebLinksMap> RdpBrandPartajsBrandWebLinksMap { get; set; } = new List<RdpBrandPartajsBrandWebLinksMap>();
}
