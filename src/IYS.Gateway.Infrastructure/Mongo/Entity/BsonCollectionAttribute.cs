namespace IYS.Gateway.Infrastructure.Mongo.Entity;

/// <summary>
/// MongoDB koleksiyon adını entity sınıfına bağlamak için kullanılan attribute.
/// Sınıf düzeyinde uygulanır.
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
