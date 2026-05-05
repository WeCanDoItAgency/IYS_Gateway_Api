using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Departments
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? Mfasmsforce { get; set; }

    public byte? Mfatype { get; set; }

    public bool? IsAbletoSendSmsAfterPush { get; set; }

    public bool? IstatisliklerVeBransBazliUretimGosterilsinMi { get; set; }

    public bool? MerkezeSorKayitlarimGosterilsinMi { get; set; }

    public bool? MerkezeSorKayitIstatislikleriGosterilsinMi { get; set; }

    public bool? IleriVadeGrafigiGosterilsinMi { get; set; }

    public bool? IsTakipYonetimiIstatistikleriGosterilsinMi { get; set; }

    public bool? KayipGrafigiGosterilsinMi { get; set; }

    public bool? DuyurularGosterilsinMi { get; set; }

    public bool ChatBotGosterilsinMi { get; set; }

    public bool? WebservisHatalariGosterilsinMi { get; set; }

    public bool? AktifKullaniciVeSktGösterilsinMi { get; set; }

    public bool? DijitalKanallarGösterilsinMi { get; set; }

    public bool? SubePazarlamaGösterilsinMi { get; set; }

    public bool? OnlineLeadGösterilsinMi { get; set; }

    public bool? CanliUretimTakibiGosterilsinMi { get; set; }

    public bool? TeminatAlarmGosterilsinMi { get; set; }

    public virtual ICollection<DepartmanQueryTypeMapping> DepartmanQueryTypeMapping { get; set; } = new List<DepartmanQueryTypeMapping>();

    public virtual ICollection<Kullanicilar> Kullanicilar { get; set; } = new List<Kullanicilar>();

    public virtual ICollection<Talepler> Talepler { get; set; } = new List<Talepler>();
}
