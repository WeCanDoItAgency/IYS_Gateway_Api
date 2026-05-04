using System;
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
    public class GenericMongoRepository : IGenericMongoRepository
    {
        private readonly GenericMongoConnectionManager _connectionManager;
        private readonly OurMongosServer _defaultServer;
        private readonly string _defaultDatabase;

        public GenericMongoRepository(
            OurMongosServer defaultServer = OurMongosServer.MONGO_206,
            string defaultDatabase = "MongoPortal")
        {
            _connectionManager = GenericMongoConnectionManager.Instance;
            _defaultServer = defaultServer;
            _defaultDatabase = defaultDatabase;
        }

        private static string GetCollectionName<T>() where T : MongoDbEntity
        {
            var attr = typeof(T).GetCustomAttribute<BsonCollectionAttribute>();
            return attr?.CollectionName ?? typeof(T).Name;
        }

        private IMongoCollection<T> GetCollectionWithFallback<T>(IMongoDatabase db) where T : MongoDbEntity
        {
            string collectionName = GetCollectionName<T>();
            string lowerCollectionName = collectionName.ToLowerInvariant();

            var existingCollections = db.ListCollectionNames().ToList();

            if (existingCollections.Contains(collectionName))
            {
                return db.GetCollection<T>(collectionName);
            }
            if (existingCollections.Contains(lowerCollectionName))
            {
                return db.GetCollection<T>(lowerCollectionName);
            }

            // Fallback (eğer henüz oluşturulmamışsa varsayılan ile devam et, driver ilk yazışta oluşturur)
            return db.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> GetCollection<T>(OurMongosServer server = default, string? database = null) where T : MongoDbEntity
        {
            var targetServer = server == default ? _defaultServer : server;
            var targetDatabase = database ?? _defaultDatabase;
            var db = _connectionManager.GetDatabase(targetServer, targetDatabase);
            return GetCollectionWithFallback<T>(db);
        }

        public IMongoCollection<T> GetCollection<T>(string connectionString, string database) where T : MongoDbEntity
        {
            var db = _connectionManager.GetDatabase(connectionString, database);
            return GetCollectionWithFallback<T>(db);
        }

        public IGenericMongoQueryBuilder<T> Query<T>() where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(_defaultServer, _defaultDatabase), this);
        }

        public IGenericMongoQueryBuilder<T> Query<T>(OurMongosServer server, string database) where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(server, database), this);
        }

        public IGenericMongoQueryBuilder<T> Query<T>(string connectionString, string database) where T : MongoDbEntity
        {
            return new GenericMongoQueryBuilder<T>(GetCollection<T>(connectionString, database), this);
        }

        public async Task<T?> GetByIdAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync(ct);
        }

        public async Task<T> InsertAsync<T>(T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await collection.InsertOneAsync(entity, options, ct);
            return entity;
        }

        public async Task<bool> InsertManyAsync<T>(IEnumerable<T> entities, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            var options = new InsertManyOptions { IsOrdered = false, BypassDocumentValidation = false };
            await collection.InsertManyAsync(entities, options, ct);
            return true;
        }

        public async Task<T?> UpdateAsync<T>(string id, T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            return await collection.FindOneAndReplaceAsync(x => x.Id == id, entity, cancellationToken: ct);
        }

        public async Task<bool> DeleteAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            var result = await collection.FindOneAndDeleteAsync(x => x.Id == id, cancellationToken: ct);
            return result != null;
        }

        public async Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> filter, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            var result = await collection.DeleteManyAsync(filter, cancellationToken: ct);
            return result.DeletedCount;
        }

        public async Task<IClientSessionHandle> StartSessionAsync(OurMongosServer server = default, CancellationToken ct = default)
        {
            var dbServer = server == default ? OurMongosServer.MONGO_206 : server;
            var client = _connectionManager.GetClient(dbServer);
            return await client.StartSessionAsync(cancellationToken: ct);
        }

        public async Task<BulkWriteResult<T>> BulkWriteAsync<T>(IEnumerable<WriteModel<T>> requests, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity
        {
            var collection = GetCollection<T>(server, database);
            var options = new BulkWriteOptions { IsOrdered = false }; // Parallel execution for performance by default
            return await collection.BulkWriteAsync(requests, options, ct);
        }
    }
}
