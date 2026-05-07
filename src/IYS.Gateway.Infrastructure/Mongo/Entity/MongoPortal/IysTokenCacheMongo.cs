using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// IYS Token Cache entity'si. Multi-pod ortamda distributed token yönetimi için kullanılır.
/// Her firma için aktif access_token ve refresh_token bilgilerini MongoDB'de saklar.
/// Konum: MONGO_52 / GlobalAdresses:MongoDbSettings52Database
/// </summary>
[BsonCollection("IysTokenCache")]
[BsonIgnoreExtraElements]
public class IysTokenCacheMongo : MongoDbEntity
{
    /// <summary>Firmanın benzersiz tanımlayıcısı (string olarak — legacy driver uyumu)</summary>
    public string FirmGuid { get; set; } = null!;

    /// <summary>Firmanın MSSQL Id'si (referans amaçlı)</summary>
    public int FirmId { get; set; }

    /// <summary>IYS OAuth2 access token değeri</summary>
    public string AccessToken { get; set; } = null!;

    /// <summary>IYS OAuth2 refresh token değeri</summary>
    public string RefreshToken { get; set; } = null!;

    /// <summary>Access token'ın geçerlilik bitiş zamanı (UTC + expires_in saniye)</summary>
    public DateTime AccessTokenExpiresAt { get; set; }

    /// <summary>Refresh token'ın geçerlilik bitiş zamanı (UTC + refresh_expires_in saniye)</summary>
    public DateTime RefreshTokenExpiresAt { get; set; }

    /// <summary>Firma için çözümlenen IYS brandCode değeri. Sık değişmez, cache'lenir.</summary>
    public int? CachedBrandCode { get; set; }

    /// <summary>BrandCode'un en son çözümlendiği tarih</summary>
    public DateTime? BrandCodeResolvedAt { get; set; }

    /// <summary>Kaydın oluşturulma tarihi</summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>Kaydın son güncellenme tarihi</summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>MongoDB esneklik alanı — gelecekte eklenecek alanlar için</summary>
}
