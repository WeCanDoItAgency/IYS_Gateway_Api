using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewRdpBrandPartajs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? SelfUserId { get; set; }

    public int? BrandId { get; set; }

    public int? SubBrandId { get; set; }

    public string? AgentUsername { get; set; }

    public string? AgentPassword { get; set; }

    public bool? IsProxyRequired { get; set; }

    public bool? IsMfa { get; set; }

    public string? Mfacode { get; set; }

    public string? Mfasecret { get; set; }

    public string? DisMfasecret { get; set; }

    public string? SmsSelector { get; set; }

    public bool? IsSelfUser { get; set; }

    public string? SelfUserName { get; set; }

    public string? SelfUserPassword { get; set; }

    public string? SelfUserOtpcode { get; set; }

    public string? SelfUserSmsUrl { get; set; }

    public string? SelfUserRecaptchaCode { get; set; }

    public string? SelfUserPhone { get; set; }

    public string? SelfUserRecaptchaCallback { get; set; }

    public bool? IsSpecialProxy { get; set; }

    public string? SpecialProxyAddress { get; set; }

    public string? SpecialProxyPort { get; set; }

    public string? SpecialProxyUsername { get; set; }

    public string? SpecialProxyPassword { get; set; }

    public bool? IsCenter { get; set; }

    public int? SmsqrId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsShare { get; set; }

    public bool? IsOtherFirmsShare { get; set; }

    public int? RobotRunType { get; set; }

    public int? ReferencePartajId { get; set; }

    public bool? QueueStatus { get; set; }

    public bool? SessionOlusturulsunMu { get; set; }

    public virtual NewBrands? Brand { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<RdpBrandPartajSktAuthMap> RdpBrandPartajSktAuthMap { get; set; } = new List<RdpBrandPartajSktAuthMap>();

    public virtual ICollection<RdpBrandPartajSubUsers> RdpBrandPartajSubUsers { get; set; } = new List<RdpBrandPartajSubUsers>();

    public virtual ICollection<RdpBrandPartajUserAuthMap> RdpBrandPartajUserAuthMap { get; set; } = new List<RdpBrandPartajUserAuthMap>();

    public virtual ICollection<RdpBrandPartajsBrandWebLinksMap> RdpBrandPartajsBrandWebLinksMap { get; set; } = new List<RdpBrandPartajsBrandWebLinksMap>();

    public virtual ICollection<RdpBrandPartajsQueryTypeMap> RdpBrandPartajsQueryTypeMap { get; set; } = new List<RdpBrandPartajsQueryTypeMap>();
}
