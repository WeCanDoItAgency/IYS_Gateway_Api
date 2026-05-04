using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

/// <summary>
/// MongoDB-based distributed lock entity'si.
/// Multi-pod ortamda aynı firma için eşzamanlı token alma isteklerini engellemek için kullanılır.
/// 
/// Çalışma prensibi:
/// - Pod token almak istediğinde: InsertOneAsync ile lock kaydı oluşturur (FirmGuid üzerinde unique index)
/// - Zaten lock varsa: DuplicateKeyException fırlatılır → pod bekler ve cache'den okur
/// - Token alındıktan sonra: Lock kaydı silinir
/// - TTL index ile ölü lock'lar otomatik temizlenir (30 saniye sonra)
/// 
/// Konum: MONGO_52 / GlobalAdresses:MongoDbSettings52Database
/// </summary>
[BsonCollection("IysTokenLock")]
[BsonIgnoreExtraElements]
public class IysTokenLockMongo : MongoDbEntity
{
    /// <summary>Lock'un ait olduğu firma (unique index ile korunur)</summary>
    public string FirmGuid { get; set; } = null!;

    /// <summary>Lock'u alan pod'un tanımlayıcısı (debug amaçlı)</summary>
    public string LockedBy { get; set; } = null!;

    /// <summary>Lock'un oluşturulma zamanı — TTL index bu alana bağlıdır</summary>
    public DateTime CreatedAt { get; set; }
}
