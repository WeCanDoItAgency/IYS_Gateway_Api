using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmssliders
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? PgId { get; set; }

    public int? Order { get; set; }

    public string? SliderImagePath { get; set; }

    public bool? IsActive { get; set; }

    public int LanguageId { get; set; }

    public string? SliderContent { get; set; }

    public string? SliderTitle { get; set; }

    public int? WidgetId { get; set; }

    public string? WidgetLocation { get; set; }

    public bool? IsForLoggedInUser { get; set; }

    public string? SliderLocation { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? ComponentId { get; set; }

    public string? T1branch1Title { get; set; }

    public string? T1branch1Desc { get; set; }

    public string? T1branch1Link { get; set; }

    public string? T1branch1Icon { get; set; }

    public string? T1branch1BgColor { get; set; }

    public string? T1branch2Title { get; set; }

    public string? T1branch2Desc { get; set; }

    public string? T1branch2Link { get; set; }

    public string? T1branch2Icon { get; set; }

    public string? T1branch2BgColor { get; set; }

    public string? T1branch3Title { get; set; }

    public string? T1branch3Desc { get; set; }

    public string? T1branch3Link { get; set; }

    public string? T1branch3Icon { get; set; }

    public string? T1branch3BgColor { get; set; }

    public string? T1branch4Title { get; set; }

    public string? T1branch4Desc { get; set; }

    public string? T1branch4Link { get; set; }

    public string? T1branch4Icon { get; set; }

    public string? T1branch4BgColor { get; set; }

    public string? T1hemenBaslaLink { get; set; }

    public string? T1kesfetLink { get; set; }

    public string? T2buttonLink { get; set; }

    public string? T3widget1Title { get; set; }

    public string? T3widget1Desc { get; set; }

    public string? T3widget1BgColor { get; set; }

    public string? T3widget2Title { get; set; }

    public string? T3widget2Desc { get; set; }

    public string? T3widget2BgColor { get; set; }

    public string? T3widget3Title { get; set; }

    public string? T3widget3Desc { get; set; }

    public string? T3widget3BgColor { get; set; }

    public string? T3widget4Title { get; set; }

    public string? T3widget4Desc { get; set; }

    public string? T3widget4BgColor { get; set; }

    public string? T3widget1Image { get; set; }

    public string? T3widget2Image { get; set; }

    public string? T3widget3Image { get; set; }

    public string? T3widget4Image { get; set; }

    public string? T4branch1Title { get; set; }

    public string? T4branch1Desc { get; set; }

    public string? T4branch1Link { get; set; }

    public string? T4branch1Icon { get; set; }

    public string? T4branch1BgColor { get; set; }

    public string? T4branch2Title { get; set; }

    public string? T4branch2Desc { get; set; }

    public string? T4branch2Link { get; set; }

    public string? T4branch2Icon { get; set; }

    public string? T4branch2BgColor { get; set; }

    public string? T4widget1Title { get; set; }

    public string? T4widget1Desc { get; set; }

    public string? T4widget1BgColor { get; set; }

    public string? T4widget1Image { get; set; }

    public string? T4widget2Title { get; set; }

    public string? T4widget2Desc { get; set; }

    public string? T4widget2BgColor { get; set; }

    public string? T4widget2Image { get; set; }

    public bool? ShowSocialLink { get; set; }

    public string? MobileSliderImagePath { get; set; }

    public int? Version { get; set; }

    public string? T1kampanyaLink { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public string? TabletSliderImagePath { get; set; }

    public string? MobileStorySliderImagePath { get; set; }

    public string? MobileResponsiveSliderImagePath { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual AcenteOnlineCmssites Site { get; set; } = null!;

    public virtual Subeler Skt { get; set; } = null!;
}
