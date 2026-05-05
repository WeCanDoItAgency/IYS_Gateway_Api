using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineIletisim
{
    public int Id { get; set; }

    public int FirmaId { get; set; }

    public int? SubeId { get; set; }

    public Guid? Guid { get; set; }

    public string? Telefon { get; set; }

    public string? Telefon2 { get; set; }

    public string? Email { get; set; }

    public string? WhatsAppTelefon { get; set; }

    public string? Sehir { get; set; }

    public string? Ilce { get; set; }

    public string? Adress { get; set; }

    public string? FacebookUrl { get; set; }

    public string? LocationMap { get; set; }

    public string? LinkedinUrl { get; set; }

    public string? TwitterUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public string? YoutubeUrl { get; set; }

    public string? SeoKeywords { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
