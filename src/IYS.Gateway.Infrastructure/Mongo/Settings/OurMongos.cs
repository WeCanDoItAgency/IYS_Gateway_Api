namespace IYS.Gateway.Infrastructure.Mongo.Settings;

/// <summary>
/// MongoDB sunucu tanımlayıcıları.
/// </summary>
public enum OurMongosServer
{
    MONGO_206 = 1,
    MONGO_51 = 4,
    MONGO_52 = 5,
    MONGO_53 = 6,
    MONGO_URETIM = 7
}

/// <summary>
/// MongoDB bağlantı ayarları. Server ve veritabanı adını taşır.
/// </summary>
public class OurMongos
{
    public OurMongosServer MongoServer { get; set; }
    public string DatabaseName { get; set; } = "acente365";
}
