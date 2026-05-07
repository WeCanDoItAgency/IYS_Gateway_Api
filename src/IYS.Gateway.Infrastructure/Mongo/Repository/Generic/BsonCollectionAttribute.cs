using System;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic;

/// <summary>
/// MongoDB koleksiyon adını entity sınıfına bağlamak için kullanılan attribute.
/// Repository katmanının parçasıdır.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string CollectionName { get; }

    public BsonCollectionAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}
