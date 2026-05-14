using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// <see cref="IGenericMongoRepository"/> implementasyonu.
    /// Multi-server MongoDB altyapısı üzerinde CRUD, Query Builder ve Bulk operasyonlar sunar.
    /// 
    /// <para><b>Connection Management:</b> <see cref="GenericMongoConnectionManager"/> singleton
    /// üzerinden client cache'leme yapılır.</para>
    /// <para><b>Collection Resolution:</b> Koleksiyon adları case-insensitive fallback ile çözümlenir
    /// ve <c>_collectionNameCache</c> ile cache'lenir (round-trip'i önler).</para>
    /// </summary>
    public class GenericMongoRepository : IGenericMongoRepository
    {
        private readonly GenericMongoConnectionManager _connectionManager;
        private readonly OurMongosServer _defaultServer;
        private readonly string _defaultDatabase;

        /// <summary>
        /// Çözümlenmiş koleksiyon adlarını cache'ler.
        /// Key: "databaseName:ClassName" → Value: gerçek koleksiyon adı.
        /// Her sorgu için ListCollectionNames() round-trip'ini engeller.
        /// </summary>
        private static readonly ConcurrentDictionary<string, string> _collectionNameCache = new();

        /// <summary>
        /// Yeni bir GenericMongoRepository oluşturur.
        /// </summary>
        /// <param name="defaultServer">Varsayılan MongoDB sunucusu. Varsayılan: MONGO_206.</param>
        /// <param name="defaultDatabase">Varsayılan veritabanı adı. Varsayılan: MongoPortal.</param>
        public GenericMongoRepository(
            OurMongosServer defaultServer = OurMongosServer.MONGO_206,
            string defaultDatabase = "MongoPortal")
        {
            _connectionManager = GenericMongoConnectionManager.Instance;
            _defaultServer = defaultServer;
            _defaultDatabase = defaultDatabase;
        }

        /// <summary>
        /// Entity tipinden <see cref="BsonCollectionAttribute"/> ile koleksiyon adını çözümler.
        /// Attribute yoksa sınıf adı kullanılır.
        /// </summary>
        private static string GetCollectionName<T>() where T : MongoDbEntity
        {
            var attr = typeof(T).GetCustomAttribute<BsonCollectionAttribute>();
            return attr?.CollectionName ?? typeof(T).Name;
        }

        /// <summary>
        /// Koleksiyon adını case-insensitive fallback ile çözümler ve cache'ler.
        /// İlk çağrıda <c>ListCollectionNames()</c> ile MongoDB'ye round-trip yapılır,
        /// sonraki çağrılarda cache'den döner.
        /// </summary>
        private IMongoCollection<T> GetCollectionWithFallback<T>(IMongoDatabase db) where T : MongoDbEntity
        {
            string collectionName = GetCollectionName<T>();
            var cacheKey = $"{db.DatabaseNamespace.DatabaseName}:{collectionName}";

            if (_collectionNameCache.TryGetValue(cacheKey, out var cachedName))
                return db.GetCollection<T>(cachedName);

            string lowerCollectionName = collectionName.ToLowerInvariant();

            try
            {
                var existingCollections = db.ListCollectionNames().ToList();

                var resolvedName = existingCollections.Contains(collectionName) ? collectionName
                    : existingCollections.Contains(lowerCollectionName) ? lowerCollectionName
                    : collectionName;

                _collectionNameCache.TryAdd(cacheKey, resolvedName);
                return db.GetCollection<T>(resolvedName);
            }
            catch
            {
                // ListCollectionNames başarısız olursa (yetki, ağ vb.) — varsayılan adla devam et
                _collectionNameCache.TryAdd(cacheKey, collectionName);
                return db.GetCollection<T>(collectionName);
            }
        }

        /// <inheritdoc />
        public IMongoCollection<T> GetCollection<T>(OurMongosServer server = default, string? database = null) where T : MongoDbEntity
        {
            var targetServer = server == default ? _defaultServer : server;
            var targetDatabase = database ?? _defaultDatabase;
            var db = _connectionManager.GetDatabase(targetServer, targetDatabase);
            return GetCollectionWithFallback<T>(db);
        }

        /// <inheritdoc />
        public IMongoCollection<T> GetCollection<T>(string connectionString, string database) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(database))
                throw new ArgumentNullException(nameof(database));

            var db = _connectionManager.GetDatabase(connectionString, database);
            return GetCollectionWithFallback<T>(db);
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Query<T>() where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(_defaultServer, _defaultDatabase), this);
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Query<T>(OurMongosServer server, string database) where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(server, database), this);
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Query<T>(string connectionString, string database) where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(connectionString, database), this);
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var collection = GetCollection<T>(server, database);
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync(ct);
        }

        /// <inheritdoc />
        public async Task<T> InsertAsync<T>(T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var collection = GetCollection<T>(server, database);
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await collection.InsertOneAsync(entity, options, ct);
            return entity;
        }

        /// <inheritdoc />
        public async Task<bool> InsertManyAsync<T>(IEnumerable<T> entities, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var collection = GetCollection<T>(server, database);
            var options = new InsertManyOptions { IsOrdered = false, BypassDocumentValidation = false };
            await collection.InsertManyAsync(entities, options, ct);
            return true;
        }

        /// <inheritdoc />
        public async Task<T?> UpdateAsync<T>(string id, T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var collection = GetCollection<T>(server, database);
            return await collection.FindOneAndReplaceAsync(x => x.Id == id, entity, cancellationToken: ct);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var collection = GetCollection<T>(server, database);
            var result = await collection.FindOneAndDeleteAsync(x => x.Id == id, cancellationToken: ct);
            return result != null;
        }

        /// <inheritdoc />
        public async Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> filter, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var collection = GetCollection<T>(server, database);
            var result = await collection.DeleteManyAsync(filter, cancellationToken: ct);
            return result.DeletedCount;
        }

        /// <inheritdoc />
        public async Task<IClientSessionHandle> StartSessionAsync(OurMongosServer server = default, CancellationToken ct = default)
        {
            var dbServer = server == default ? OurMongosServer.MONGO_206 : server;
            var client = _connectionManager.GetClient(dbServer);
            return await client.StartSessionAsync(cancellationToken: ct);
        }

        /// <inheritdoc />
        public async Task<BulkWriteResult<T>> BulkWriteAsync<T>(IEnumerable<WriteModel<T>> requests, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            if (requests == null) throw new ArgumentNullException(nameof(requests));

            var collection = GetCollection<T>(server, database);
            var options = new BulkWriteOptions { IsOrdered = false }; // Paralel execution for performance by default
            return await collection.BulkWriteAsync(requests, options, ct);
        }
    }
}
