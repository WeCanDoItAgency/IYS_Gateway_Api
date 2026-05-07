using System;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic;

/// <summary>
/// MongoDB koleksiyon adını entity sınıfına bağlayan attribute.
/// Bu attribute tanımlanmadığında koleksiyon adı olarak sınıf adı kullanılır.
/// 
/// <para>Kullanım:</para>
/// <code>
/// [BsonCollection("iysRequestConsents")]
/// public class IysRequestConsentMongo : MongoDbEntity { }
/// </code>
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class BsonCollectionAttribute : Attribute
{
    /// <summary>MongoDB koleksiyon adı.</summary>
    public string CollectionName { get; }

    /// <summary>
    /// Yeni bir BsonCollection attribute oluşturur.
    /// </summary>
    /// <param name="name">MongoDB koleksiyon adı. Null veya boş olamaz.</param>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> null veya boş ise.</exception>
    public BsonCollectionAttribute(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Koleksiyon adı boş olamaz.");
        CollectionName = name;
    }
}
