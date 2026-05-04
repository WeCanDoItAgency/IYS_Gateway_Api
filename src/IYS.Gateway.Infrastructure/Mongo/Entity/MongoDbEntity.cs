using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity;

/// <summary>
/// MongoDB entity temel marker interface'i.
/// </summary>
public interface IEntity
{
}

/// <summary>
/// Tipli key desteği olan entity interface'i.
/// </summary>
public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
{
    public TKey Id { get; }
}

/// <summary>
/// Tüm MongoDB entity'leri için temel sınıf.
/// ObjectId tabanlı Id özelliği taşır.
/// </summary>
public class MongoDbEntity : IEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
}
