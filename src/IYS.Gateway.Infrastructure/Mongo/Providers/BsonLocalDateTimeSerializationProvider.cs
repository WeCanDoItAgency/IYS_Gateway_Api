using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace IYS.Gateway.Infrastructure.Mongo.Providers;

/// <summary>
/// MongoDB DateTime alanlarını Local zaman dilimine göre serialize/deserialize eder.
/// UTC yerine lokal saat kullanılmasını sağlar.
/// </summary>
public class BsonLocalDateTimeSerializationProvider : IBsonSerializationProvider
{
    public IBsonSerializer? GetSerializer(Type type)
    {
        return type == typeof(DateTime) ? DateTimeSerializer.LocalInstance : null;
    }
}
