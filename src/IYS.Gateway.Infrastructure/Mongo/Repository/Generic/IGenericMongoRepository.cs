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
    /// MongoDB CRUD ve sorgu operasyonları için merkezi repository arayüzü.
    /// Farklı sunucu/veritabanı hedeflerini destekler (MONGO_206, MONGO_52, MONGO_53 vb.).
    /// 
    /// <para><b>Query Builder:</b> <c>Query&lt;T&gt;()</c> ile fluent builder başlatılır.</para>
    /// <para><b>Direct CRUD:</b> <c>InsertAsync</c>, <c>UpdateAsync</c>, <c>DeleteAsync</c> ile
    /// basit işlemler doğrudan yapılır.</para>
    /// <para><b>Escape Hatch:</b> <c>GetCollection&lt;T&gt;()</c> ile native MongoDB driver koleksiyonuna erişilir.</para>
    /// </summary>
    public interface IGenericMongoRepository
    {
        // ═══════════════════════════════════════════════════════════════
        // QUERY BUILDER GİRİŞ NOKTALARI
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Varsayılan sunucu/veritabanı üzerinde fluent sorgu builder başlatır.
        /// </summary>
        /// <typeparam name="T">Hedef entity tipi.</typeparam>
        /// <returns>Zincirleme sorgu oluşturmak için <see cref="IGenericMongoQueryBuilder{T}"/>.</returns>
        IGenericMongoQueryBuilder<T> Query<T>() where T : MongoDbEntity;

        /// <summary>
        /// Belirtilen sunucu ve veritabanı üzerinde fluent sorgu builder başlatır.
        /// Cross-server sorgular için kullanılır (ör: MONGO_52/acente365).
        /// </summary>
        /// <typeparam name="T">Hedef entity tipi.</typeparam>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <param name="database">Hedef veritabanı adı.</param>
        /// <returns>Zincirleme sorgu oluşturmak için <see cref="IGenericMongoQueryBuilder{T}"/>.</returns>
        IGenericMongoQueryBuilder<T> Query<T>(OurMongosServer server, string database) where T : MongoDbEntity;

        /// <summary>
        /// Custom connection string ile fluent sorgu builder başlatır.
        /// Standart sunucu enum'ında tanımlı olmayan hedefler için kullanılır.
        /// </summary>
        /// <typeparam name="T">Hedef entity tipi.</typeparam>
        /// <param name="connectionString">MongoDB bağlantı dizesi.</param>
        /// <param name="database">Hedef veritabanı adı.</param>
        /// <returns>Zincirleme sorgu oluşturmak için <see cref="IGenericMongoQueryBuilder{T}"/>.</returns>
        IGenericMongoQueryBuilder<T> Query<T>(string connectionString, string database) where T : MongoDbEntity;

        // ═══════════════════════════════════════════════════════════════
        // DİREKT KOLEKSİYON ERİŞİMİ (Escape Hatch)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Native MongoDB <see cref="IMongoCollection{T}"/> referansı döner.
        /// BulkWrite, aggregation pipeline veya özel sorgular için escape hatch olarak kullanılır.
        /// Koleksiyon adı case-insensitive fallback ile çözümlenir.
        /// </summary>
        /// <typeparam name="T">Hedef entity tipi.</typeparam>
        /// <param name="server">Hedef sunucu. Varsayılan: MONGO_206.</param>
        /// <param name="database">Hedef veritabanı. Varsayılan: MongoPortal.</param>
        /// <returns>MongoDB koleksiyon referansı.</returns>
        IMongoCollection<T> GetCollection<T>(OurMongosServer server = default, string? database = null) where T : MongoDbEntity;

        /// <summary>
        /// Custom connection string ile native MongoDB koleksiyonuna erişir.
        /// </summary>
        /// <typeparam name="T">Hedef entity tipi.</typeparam>
        /// <param name="connectionString">MongoDB bağlantı dizesi.</param>
        /// <param name="database">Hedef veritabanı adı.</param>
        /// <returns>MongoDB koleksiyon referansı.</returns>
        IMongoCollection<T> GetCollection<T>(string connectionString, string database) where T : MongoDbEntity;

        // ═══════════════════════════════════════════════════════════════
        // DİREKT CRUD OPERASYONLARI
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// MongoDB ObjectId ile tek kayıt getirir.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="id">MongoDB document Id (string).</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Bulunan entity veya null.</returns>
        Task<T?> GetByIdAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        /// <summary>
        /// Yeni kayıt ekler. Document validation uygulanır.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="entity">Eklenecek entity. Null olamaz.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Eklenen entity (Id atanmış hali).</returns>
        /// <exception cref="ArgumentNullException"><paramref name="entity"/> null ise.</exception>
        Task<T> InsertAsync<T>(T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        /// <summary>
        /// Toplu kayıt ekler. IsOrdered=false (paralel) çalışır.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="entities">Eklenecek entity listesi. Null veya boş olamaz.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>İşlem başarılı ise true.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="entities"/> null ise.</exception>
        Task<bool> InsertManyAsync<T>(IEnumerable<T> entities, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        /// <summary>
        /// Id ile bulunan kaydı tamamen değiştirir (Replace).
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="id">Güncellenecek document Id.</param>
        /// <param name="entity">Yeni entity değeri.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Güncellenmeden önceki entity veya null (bulunamadıysa).</returns>
        Task<T?> UpdateAsync<T>(string id, T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        /// <summary>
        /// Id ile bulunan kaydı siler.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="id">Silinecek document Id.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Kayıt bulunup silindiyse true.</returns>
        Task<bool> DeleteAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        /// <summary>
        /// Filtreye uyan tüm kayıtları siler.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="filter">Silme filtresi.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Silinen kayıt sayısı.</returns>
        Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> filter, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        // ═══════════════════════════════════════════════════════════════
        // SESSION & TRANSACTION
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// MongoDB client session başlatır. Multi-document transaction'lar için gereklidir.
        /// </summary>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>MongoDB session handle.</returns>
        Task<IClientSessionHandle> StartSessionAsync(OurMongosServer server = default, CancellationToken ct = default);

        // ═══════════════════════════════════════════════════════════════
        // BULK OPERASYONLAR
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Toplu yazma operasyonu çalıştırır (Insert, Update, Delete karışık).
        /// IsOrdered=false ile paralel çalışır.
        /// </summary>
        /// <typeparam name="T">Entity tipi.</typeparam>
        /// <param name="requests">Yazma modelleri listesi.</param>
        /// <param name="server">Hedef sunucu.</param>
        /// <param name="database">Hedef veritabanı.</param>
        /// <param name="ct">İptal token'ı.</param>
        /// <returns>Bulk write sonucu (InsertedCount, ModifiedCount, DeletedCount).</returns>
        Task<BulkWriteResult<T>> BulkWriteAsync<T>(IEnumerable<WriteModel<T>> requests, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
    }
}
