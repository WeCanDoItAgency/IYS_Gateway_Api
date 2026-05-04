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
    public interface IGenericMongoQueryBuilder<T> where T : MongoDbEntity
    {
        IGenericMongoQueryBuilder<T> Where(Expression<Func<T, bool>> predicate);
        IGenericMongoQueryBuilder<T> Where(FilterDefinition<T> filter);

        IGenericMongoQueryBuilder<T> OrderBy(Expression<Func<T, object>> field);
        IGenericMongoQueryBuilder<T> OrderByDescending(Expression<Func<T, object>> field);

        IGenericMongoQueryBuilder<T> Skip(int count);
        IGenericMongoQueryBuilder<T> Take(int count);

        // Same-Server Lookup (Strongly Typed for keys, Mandatory Alias)
        IGenericMongoQueryBuilder<T> Lookup<TForeign>(
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity;

        // Cross-Server Lookup (Strongly Typed for keys, Mandatory Alias)
        IGenericMongoQueryBuilder<T> LookupCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity;

        // Cross-Server Filter & Join (Reverse Query)
        IGenericMongoQueryBuilder<T> WhereCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            Expression<Func<TForeign, bool>> foreignFilter,
            string @as) where TForeign : MongoDbEntity;

        // Projection (Alan Seçme / Gizleme)
        IGenericMongoQueryBuilder<T> SelectOnly(params Expression<Func<T, object>>[] fields);
        IGenericMongoQueryBuilder<T> IgnoreFields(params Expression<Func<T, object>>[] fields);

        // Terminals
        Task<List<T>> ToListAsync(CancellationToken ct = default);
        Task<PagedResult<T>> ToPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default);
        Task<T?> FirstOrDefaultAsync(CancellationToken ct = default);
        Task<long> CountAsync(CancellationToken ct = default);
        Task<bool> AnyAsync(CancellationToken ct = default);
        
        // Partial Updates
        Task<UpdateResult> UpdateOneAsync(UpdateDefinition<T> update, CancellationToken ct = default);
        Task<UpdateResult> UpdateManyAsync(UpdateDefinition<T> update, CancellationToken ct = default);

        // Atomic Upsert & Find-and-Modify
        Task<UpdateResult> UpsertOneAsync(UpdateDefinition<T> update, CancellationToken ct = default);
        Task<T?> FindOneAndUpdateAsync(UpdateDefinition<T> update, bool returnAfter = true, CancellationToken ct = default);
        Task<T?> FindOneAndDeleteAsync(CancellationToken ct = default);

        // Insert & Delete
        Task InsertOneAsync(T document, CancellationToken ct = default);
        Task<DeleteResult> DeleteOneAsync(CancellationToken ct = default);
    }
}
