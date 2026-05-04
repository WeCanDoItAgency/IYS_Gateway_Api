using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// IYS API yanıt cache entity'si. Multi-pod ortamda distributed cache olarak kullanılır.
/// TTL index ile otomatik expire olur — tüm pod'lar aynı cache'i okur/yazar.
/// Konum: MONGO_52 / GlobalAdresses:MongoDbSettings52Database
/// 
/// Cache Key formatı: {FirmGuid}:{Endpoint}:{ParamHash}
/// Örnek: "3fa85f64-xxxx:consent_status:a1b2c3d4"
/// </summary>
[BsonCollection("IysResponseCache")]
[BsonIgnoreExtraElements]
public class IysResponseCacheMongo : MongoDbEntity
{
    /// <summary>Benzersiz cache anahtarı: {FirmGuid}:{Endpoint}:{ParamHash}</summary>
    public string CacheKey { get; set; } = null!;

    /// <summary>İlişkili firma GUID'i (sorgu kolaylığı için)</summary>
    public string FirmGuid { get; set; } = null!;

    /// <summary>Cache'lenen endpoint adı (consent_status, brands, sources vb.)</summary>
    public string Endpoint { get; set; } = null!;

    /// <summary>IYS API'den dönen JSON yanıt (serialized string)</summary>
    public string ResponseJson { get; set; } = null!;

    /// <summary>Kaydın oluşturulma tarihi — TTL index bu alan üzerinden çalışır</summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>MongoDB esneklik alanı</summary>
    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
