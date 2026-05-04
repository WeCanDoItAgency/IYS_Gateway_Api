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
    public interface IGenericMongoRepository
    {
        // --- Query Builder Entry Points ---
        IGenericMongoQueryBuilder<T> Query<T>() where T : MongoDbEntity;
        IGenericMongoQueryBuilder<T> Query<T>(OurMongosServer server, string database) where T : MongoDbEntity;
        IGenericMongoQueryBuilder<T> Query<T>(string connectionString, string database) where T : MongoDbEntity;

        // --- Direct Collection Access (Escape Hatch) ---
        IMongoCollection<T> GetCollection<T>(OurMongosServer server = default, string? database = null) where T : MongoDbEntity;
        IMongoCollection<T> GetCollection<T>(string connectionString, string database) where T : MongoDbEntity;

        // --- Direct CRUD Methods ---
        Task<T?> GetByIdAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
        
        Task<T> InsertAsync<T>(T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
        
        Task<bool> InsertManyAsync<T>(IEnumerable<T> entities, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
        
        Task<T?> UpdateAsync<T>(string id, T entity, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
        
        Task<bool> DeleteAsync<T>(string id, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
        
        Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> filter, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;

        // --- Session & Transactions ---
        Task<IClientSessionHandle> StartSessionAsync(OurMongosServer server = default, CancellationToken ct = default);

        // --- Bulk Operations ---
        Task<BulkWriteResult<T>> BulkWriteAsync<T>(IEnumerable<WriteModel<T>> requests, OurMongosServer server = default, string? database = null, CancellationToken ct = default) where T : MongoDbEntity;
    }
}
