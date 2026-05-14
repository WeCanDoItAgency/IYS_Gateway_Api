using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// MongoDB sorgu pipeline'ı oluşturmak için fluent builder arayüzü.
    /// Tek bir <c>Query&lt;T&gt;()</c> çağrısından başlayarak zincirleme Where, OrderBy,
    /// Lookup, Projection ve terminal operasyonlar (ToListAsync, CountAsync vb.) sunar.
    /// 
    /// <para><b>Yaşam döngüsü:</b> Her builder instance'ı tek kullanımlıktır.
    /// Terminal bir metot çağrıldıktan sonra aynı instance yeniden kullanılmamalıdır.</para>
    /// 
    /// <para><b>Lookup desteği:</b> Aynı sunucu içi ($lookup) ve farklı sunucular arası
    /// (cross-server in-memory join) olmak üzere iki seviye join desteklenir.</para>
    /// </summary>
    /// <typeparam name="T">Hedef MongoDB entity tipi. <see cref="MongoDbEntity"/>'den türemelidir.</typeparam>
    public interface IGenericMongoQueryBuilder<T> where T : MongoDbEntity
    {
        // ═══════════════════════════════════════════════════════════════
        // FİLTRELEME
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Lambda expression ile filtre ekler. Birden fazla çağrıda filtreler AND ile birleştirilir.
        /// </summary>
        /// <param name="predicate">Filtre koşulu. Örnek: <c>x =&gt; x.Status == "Active"</c></param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> Where(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// MongoDB <see cref="FilterDefinition{T}"/> ile filtre ekler. Karmaşık sorgular için kullanılır.
        /// Birden fazla çağrıda filtreler AND ile birleştirilir.
        /// </summary>
        /// <param name="filter">MongoDB filtre tanımı.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> Where(FilterDefinition<T> filter);

        // ═══════════════════════════════════════════════════════════════
        // SIRALAMA
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Artan sıralama ekler. Birden fazla çağrıda sıralamalar birleştirilir (Combine).
        /// </summary>
        /// <param name="field">Sıralama yapılacak alan. Örnek: <c>x =&gt; x.CreatedDate</c></param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> OrderBy(Expression<Func<T, object>> field);

        /// <summary>
        /// Azalan sıralama ekler. Birden fazla çağrıda sıralamalar birleştirilir (Combine).
        /// </summary>
        /// <param name="field">Sıralama yapılacak alan. Örnek: <c>x =&gt; x.CreatedDate</c></param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> OrderByDescending(Expression<Func<T, object>> field);

        // ═══════════════════════════════════════════════════════════════
        // SAYFALAMA
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Belirtilen sayıda kaydı atlar (paging).
        /// </summary>
        /// <param name="count">Atlanacak kayıt sayısı. Negatif değer verilirse 0 olarak işlenir.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> Skip(int count);

        /// <summary>
        /// Belirtilen sayıda kayıt çeker (paging / güvenlik limiti).
        /// </summary>
        /// <param name="count">Çekilecek maksimum kayıt sayısı. 0 veya negatif değer yok sayılır.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> Take(int count);

        // ═══════════════════════════════════════════════════════════════
        // JOIN — AYNI SUNUCU ($lookup)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Aynı MongoDB sunucusu/veritabanı içinde <c>$lookup</c> (LEFT JOIN) ekler.
        /// Sonuçlar ana entity'nin <c>ExtraElements</c> alanına <paramref name="as"/> anahtarıyla yazılır.
        /// </summary>
        /// <typeparam name="TForeign">Join yapılacak foreign entity tipi.</typeparam>
        /// <param name="localField">Ana entity'deki eşleşme alanı (FK). Örnek: <c>x =&gt; x.CariKartMongoId</c></param>
        /// <param name="foreignField">Foreign entity'deki eşleşme alanı (PK). Örnek: <c>x =&gt; x.Id</c></param>
        /// <param name="as">Sonuçların yazılacağı takma ad. Sorguda benzersiz olmalıdır.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        /// <exception cref="InvalidOperationException">Aynı alias zaten kullanıldıysa fırlatılır.</exception>
        IGenericMongoQueryBuilder<T> Lookup<TForeign>(
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity;

        // ═══════════════════════════════════════════════════════════════
        // JOIN — FARKLI SUNUCU (Cross-Server In-Memory)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Farklı bir MongoDB sunucusundaki koleksiyonla in-memory join yapar.
        /// İlk olarak local entity'lerden ID'ler toplanır, sonra foreign sunucuya batch sorgu atılır,
        /// ardından sonuçlar bellekte eşleştirilir.
        /// </summary>
        /// <typeparam name="TForeign">Foreign entity tipi.</typeparam>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <param name="database">Hedef veritabanı adı.</param>
        /// <param name="localField">Local eşleşme alanı.</param>
        /// <param name="foreignField">Foreign eşleşme alanı.</param>
        /// <param name="as">Sonuçların yazılacağı benzersiz takma ad.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        /// <exception cref="InvalidOperationException">Aynı alias zaten kullanıldıysa fırlatılır.</exception>
        /// <exception cref="NotSupportedException">Array/List tipinde alanlar kullanıldıysa fırlatılır.</exception>
        IGenericMongoQueryBuilder<T> LookupCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity;

        /// <summary>
        /// Cross-server filtreleme ve join. Foreign sunucuya önce filtre uygulanır,
        /// eşleşen ID'ler ana sorgunun WHERE koşuluna IN olarak eklenir.
        /// Sonra eşleşen foreign kayıtlar ExtraElements'e yazılır.
        /// </summary>
        /// <typeparam name="TForeign">Foreign entity tipi.</typeparam>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <param name="database">Hedef veritabanı adı.</param>
        /// <param name="localField">Local eşleşme alanı.</param>
        /// <param name="foreignField">Foreign eşleşme alanı.</param>
        /// <param name="foreignFilter">Foreign sunucuya uygulanacak filtre.</param>
        /// <param name="as">Sonuçların yazılacağı benzersiz takma ad.</param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        /// <exception cref="InvalidOperationException">Aynı alias zaten kullanıldıysa fırlatılır.</exception>
        /// <exception cref="NotSupportedException">Array/List tipinde alanlar kullanıldıysa fırlatılır.</exception>
        IGenericMongoQueryBuilder<T> WhereCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            Expression<Func<TForeign, bool>> foreignFilter,
            string @as) where TForeign : MongoDbEntity;

        // ═══════════════════════════════════════════════════════════════
        // PROJEKSİYON (Alan Seçme / Gizleme)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Sadece belirtilen alanları döner. Diğer alanlar MongoDB'den çekilmez (bant genişliği tasarrufu).
        /// </summary>
        /// <param name="fields">Dahil edilecek alanlar. Örnek: <c>x =&gt; x.Status, x =&gt; x.FirmId</c></param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> SelectOnly(params Expression<Func<T, object>>[] fields);

        /// <summary>
        /// Belirtilen alanları sonuçtan hariç tutar. Büyük alanları (ör: binary, log) gizlemek için kullanılır.
        /// </summary>
        /// <param name="fields">Hariç tutulacak alanlar. Örnek: <c>x =&gt; x.RawPayload</c></param>
        /// <returns>Fluent zincirleme için aynı builder instance'ı.</returns>
        IGenericMongoQueryBuilder<T> IgnoreFields(params Expression<Func<T, object>>[] fields);

        // ═══════════════════════════════════════════════════════════════
        // TERMİNAL OPERASYONLAR — Veri Çekme
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Tüm eşleşen kayıtları liste olarak döner.
        /// Lookup, CrossServer ve Projection ayarları uygulanır.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Eşleşen kayıtların listesi. Sonuç yoksa boş liste döner.</returns>
        Task<List<T>> ToListAsync(CancellationToken ct = default);

        /// <summary>
        /// Sayfalanmış sonuç döner. Paralel olarak toplam sayı ve veri çekilir.
        /// </summary>
        /// <param name="pageNumber">Sayfa numarası (1-tabanlı). 1'den küçük değerler 1 olarak işlenir.</param>
        /// <param name="pageSize">Sayfa başına kayıt sayısı. 1'den küçük değerler 10 olarak işlenir.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Toplam sayı ve o sayfadaki verileri içeren <see cref="PagedResult{T}"/>.</returns>
        Task<PagedResult<T>> ToPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default);

        /// <summary>
        /// İlk eşleşen kaydı döner. Sonuç yoksa null döner.
        /// Dahili olarak <c>Take(1)</c> uygular.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>İlk eşleşen kayıt veya null.</returns>
        Task<T?> FirstOrDefaultAsync(CancellationToken ct = default);

        /// <summary>
        /// Eşleşen toplam kayıt sayısını döner. Skip/Take uygulanmaz.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Toplam kayıt sayısı.</returns>
        Task<long> CountAsync(CancellationToken ct = default);

        /// <summary>
        /// En az bir eşleşen kayıt var mı kontrol eder.
        /// Dahili olarak <see cref="CountAsync"/> &gt; 0 kontrolü yapar.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Eşleşen kayıt varsa true.</returns>
        Task<bool> AnyAsync(CancellationToken ct = default);

        // ═══════════════════════════════════════════════════════════════
        // TERMİNAL OPERASYONLAR — Güncelleme / Silme
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Filtreye uyan ilk kaydı günceller.
        /// </summary>
        /// <param name="update">Güncelleme tanımı. Örnek: <c>Builders&lt;T&gt;.Update.Set(x =&gt; x.Status, "Done")</c></param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Güncelleme sonucu (MatchedCount, ModifiedCount).</returns>
        /// <exception cref="NotSupportedException">Lookup aktifken çağrılırsa fırlatılır.</exception>
        Task<UpdateResult> UpdateOneAsync(UpdateDefinition<T> update, CancellationToken ct = default);

        /// <summary>
        /// Filtreye uyan tüm kayıtları günceller.
        /// </summary>
        /// <param name="update">Güncelleme tanımı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Güncelleme sonucu.</returns>
        /// <exception cref="NotSupportedException">Lookup aktifken çağrılırsa fırlatılır.</exception>
        Task<UpdateResult> UpdateManyAsync(UpdateDefinition<T> update, CancellationToken ct = default);

        /// <summary>
        /// Filtreye uyan kaydı günceller, yoksa yeni kayıt oluşturur (upsert).
        /// </summary>
        /// <param name="update">Güncelleme tanımı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Güncelleme sonucu.</returns>
        /// <exception cref="NotSupportedException">Lookup aktifken çağrılırsa fırlatılır.</exception>
        Task<UpdateResult> UpsertOneAsync(UpdateDefinition<T> update, CancellationToken ct = default);

        /// <summary>
        /// Filtreye uyan ilk kaydı atomik olarak günceller ve döner.
        /// </summary>
        /// <param name="update">Güncelleme tanımı.</param>
        /// <param name="returnAfter">true: güncellenmiş halini döner, false: güncellenmeden önceki halini döner.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Güncellenen/önceki kayıt veya null.</returns>
        /// <exception cref="NotSupportedException">Lookup aktifken çağrılırsa fırlatılır.</exception>
        Task<T?> FindOneAndUpdateAsync(UpdateDefinition<T> update, bool returnAfter = true, CancellationToken ct = default);

        /// <summary>
        /// Filtreye uyan ilk kaydı atomik olarak siler ve döner.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Silinen kayıt veya null.</returns>
        /// <exception cref="NotSupportedException">Lookup aktifken çağrılırsa fırlatılır.</exception>
        Task<T?> FindOneAndDeleteAsync(CancellationToken ct = default);

        // ═══════════════════════════════════════════════════════════════
        // TERMİNAL OPERASYONLAR — Insert & Delete
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Belirtilen sunucu/veritabanı hedefine yeni kayıt ekler.
        /// </summary>
        /// <param name="document">Eklenecek entity. Null olamaz.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <exception cref="ArgumentNullException"><paramref name="document"/> null ise fırlatılır.</exception>
        Task InsertOneAsync(T document, CancellationToken ct = default);

        /// <summary>
        /// Filtreye uyan ilk kaydı siler.
        /// </summary>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Silme sonucu (DeletedCount).</returns>
        Task<DeleteResult> DeleteOneAsync(CancellationToken ct = default);

        // ═══════════════════════════════════════════════════════════════
        // SERVER-SIDE GRID LOADING (DevExtreme Uyumlu — Paket Bağımsız)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme grid'den gelen filter/sort/paging/group parametrelerini
        /// native MongoDB sorguya çevirip server-side çalıştırır.
        /// Mevcut Where/OrderBy zincirine ek olarak uygulanır.
        /// 
        /// <para><b>Varsayılan:</b> Tüm operasyonlar MongoDB'de çalışır.</para>
        /// <para><b>Opsiyonel:</b> <see cref="ServerSideLoadOptions.ServerSideFiltering"/> ile
        /// toplu veya <see cref="ServerSideLoadOptions.ClientSideProperties"/> ile property bazlı
        /// client-side'a düşürülebilir.</para>
        /// </summary>
        /// <param name="options">Grid yükleme parametreleri.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Veri, toplam sayı ve grup bilgisi içeren <see cref="ServerSideLoadResult"/>.</returns>
        Task<ServerSideLoadResult> LoadServerSideAsync(ServerSideLoadOptions options, CancellationToken ct = default);
        /// <summary>
        /// Typed projection ile LoadServerSideAsync. Sonucu TResult DTO'suna deserialize eder.
        /// </summary>
        Task<ServerSideLoadResult<TResult>> LoadServerSideAsync<TResult>(ServerSideLoadOptions options, CancellationToken ct = default);
    }
}
