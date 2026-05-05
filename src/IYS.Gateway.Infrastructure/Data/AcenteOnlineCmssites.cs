using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmssites
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string ConnectionString { get; set; } = null!;

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? SourceId { get; set; }

    public string? CdnDomain { get; set; }

    public string? CdnFtpPassword { get; set; }

    public string? CdnFtpServer { get; set; }

    public string? CdnFtpUsername { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public bool IsActive { get; set; }

    public string? CloudinaryCloudName { get; set; }

    public string? CloudinaryApiKey { get; set; }

    public string? CloudinaryApiSecret { get; set; }

    public string? CloudinaryFolderName { get; set; }

    public string? CloudFolderName { get; set; }

    public int? FromPlace { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public int? OwnerUserId { get; set; }

    public bool HasMobileApp { get; set; }

    public string? SalePitchMessage { get; set; }

    public string? IysMessage { get; set; }

    public virtual ICollection<AcenteOnlineCmsblogCategories> AcenteOnlineCmsblogCategories { get; set; } = new List<AcenteOnlineCmsblogCategories>();

    public virtual ICollection<AcenteOnlineCmsblogPosts> AcenteOnlineCmsblogPosts { get; set; } = new List<AcenteOnlineCmsblogPosts>();

    public virtual ICollection<AcenteOnlineCmsblogTags> AcenteOnlineCmsblogTags { get; set; } = new List<AcenteOnlineCmsblogTags>();

    public virtual ICollection<AcenteOnlineCmscoverageCategories> AcenteOnlineCmscoverageCategories { get; set; } = new List<AcenteOnlineCmscoverageCategories>();

    public virtual ICollection<AcenteOnlineCmscoveragePosts> AcenteOnlineCmscoveragePosts { get; set; } = new List<AcenteOnlineCmscoveragePosts>();

    public virtual ICollection<AcenteOnlineCmscustomerFeedbacks> AcenteOnlineCmscustomerFeedbacks { get; set; } = new List<AcenteOnlineCmscustomerFeedbacks>();

    public virtual ICollection<AcenteOnlineCmsfaqCategories> AcenteOnlineCmsfaqCategories { get; set; } = new List<AcenteOnlineCmsfaqCategories>();

    public virtual ICollection<AcenteOnlineCmsfaqPosts> AcenteOnlineCmsfaqPosts { get; set; } = new List<AcenteOnlineCmsfaqPosts>();

    public virtual ICollection<AcenteOnlineCmsinsuranceBranches> AcenteOnlineCmsinsuranceBranches { get; set; } = new List<AcenteOnlineCmsinsuranceBranches>();

    public virtual ICollection<AcenteOnlineCmsinsuranceFirms> AcenteOnlineCmsinsuranceFirms { get; set; } = new List<AcenteOnlineCmsinsuranceFirms>();

    public virtual ICollection<AcenteOnlineCmslanguages> AcenteOnlineCmslanguages { get; set; } = new List<AcenteOnlineCmslanguages>();

    public virtual ICollection<AcenteOnlineCmspageCategories> AcenteOnlineCmspageCategories { get; set; } = new List<AcenteOnlineCmspageCategories>();

    public virtual ICollection<AcenteOnlineCmspages> AcenteOnlineCmspages { get; set; } = new List<AcenteOnlineCmspages>();

    public virtual ICollection<AcenteOnlineCmssettings> AcenteOnlineCmssettings { get; set; } = new List<AcenteOnlineCmssettings>();

    public virtual ICollection<AcenteOnlineCmssliders> AcenteOnlineCmssliders { get; set; } = new List<AcenteOnlineCmssliders>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Kullanicilar? OwnerUser { get; set; }

    public virtual Subeler Skt { get; set; } = null!;
}
