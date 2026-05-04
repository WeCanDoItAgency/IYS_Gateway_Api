using IYS.Gateway.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IYS.Gateway.Infrastructure.Data;

/// <summary>
/// Acente365 veritabanına minimal erişim DbContext'i.
/// Sadece IYS karaliste/beyazliste işlemleri için BusinessRulesLog tablosunu içerir.
/// Scaffold yapıldığında bu dosya yerine scaffold çıktısı kullanılabilir.
/// </summary>
public class Acente365DbContext : DbContext
{
    public Acente365DbContext(DbContextOptions<Acente365DbContext> options) : base(options) { }

    public DbSet<BusinessRulesLog> BusinessRulesLog => Set<BusinessRulesLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessRulesLog>(entity =>
        {
            entity.ToTable("BusinessRulesLog");
            entity.HasKey(e => e.Id);
        });
    }
}
