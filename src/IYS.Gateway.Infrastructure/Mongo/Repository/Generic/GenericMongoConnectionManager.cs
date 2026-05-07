using System;
using System.Collections.Concurrent;
using IYS.Gateway.Infrastructure.Mongo.Providers;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// Thread-safe singleton MongoDB bağlantı yöneticisi.
    /// <see cref="OurMongosServer"/> enum değerlerini connection string'lere çözümler,
    /// <see cref="IMongoClient"/> instance'larını cache'ler ve serializer'ları kaydeder.
    /// 
    /// <para><b>Singleton:</b> <c>GenericMongoConnectionManager.Instance</c> üzerinden erişilir.</para>
    /// <para><b>Resilience:</b> RetryWrites, RetryReads, 30s ConnectTimeout, 30dk SocketTimeout.</para>
    /// </summary>
    public class GenericMongoConnectionManager
    {
        private static readonly Lazy<GenericMongoConnectionManager> _instance = 
            new Lazy<GenericMongoConnectionManager>(() => new GenericMongoConnectionManager());

        /// <summary>Singleton instance.</summary>
        public static GenericMongoConnectionManager Instance => _instance.Value;

        /// <summary>Connection string → IMongoClient cache. Thread-safe.</summary>
        private readonly ConcurrentDictionary<string, IMongoClient> _clients = new();
        private bool _isSerializerRegistered = false;
        private readonly object _serializerLock = new object();

        private GenericMongoConnectionManager()
        {
            RegisterSerializers();
        }

        /// <summary>
        /// BsonSerializer'ları kaydeder. Double-check locking ile thread-safe.
        /// LocalDateTime ve Guid serializer'ları kayıt edilir.
        /// </summary>
        private void RegisterSerializers()
        {
            if (!_isSerializerRegistered)
            {
                lock (_serializerLock)
                {
                    if (!_isSerializerRegistered)
                    {
                        BsonSerializer.RegisterSerializationProvider(new BsonLocalDateTimeSerializationProvider());
                        try { BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy)); } catch { }
                        _isSerializerRegistered = true;
                    }
                }
            }
        }

        /// <summary>
        /// <see cref="OurMongosServer"/> enum değerini GlobalAppSettings'den connection string'e çözümler.
        /// </summary>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <returns>Çözümlenmiş connection string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Tanımsız sunucu enum değeri.</exception>
        public string ResolveConnectionString(OurMongosServer server)
        {
            return server switch
            {
                OurMongosServer.MONGO_206 => GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings206ConnectionString"),
                OurMongosServer.MONGO_51 => GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings51ConnectionString"),
                OurMongosServer.MONGO_52 => GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52ConnectionString"),
                OurMongosServer.MONGO_53 => GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings53ConnectionString"),
                OurMongosServer.MONGO_URETIM => GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettingsUretimConnectionString"),
                _ => throw new ArgumentOutOfRangeException(nameof(server), $"Server {server} is not configured.")
            };
        }

        /// <summary>
        /// Connection string ile <see cref="IMongoClient"/> döner.
        /// İlk çağrıda client oluşturulur, sonraki çağrılarda cache'den döner.
        /// </summary>
        /// <param name="connectionString">MongoDB bağlantı dizesi.</param>
        /// <returns>Cache'lenmiş veya yeni oluşturulmuş MongoClient.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> null veya boş ise.</exception>
        public IMongoClient GetClient(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");

            return _clients.GetOrAdd(connectionString, cs =>
            {
                var settings = MongoClientSettings.FromConnectionString(cs);
                
                // Resilience & Self-Healing configurations
                settings.MaxConnectionIdleTime = TimeSpan.FromMinutes(1);
                settings.SocketTimeout = TimeSpan.FromMinutes(30);
                settings.ConnectTimeout = TimeSpan.FromSeconds(30);
                settings.RetryWrites = true;
                settings.RetryReads = true;
                
                return new MongoClient(settings);
            });
        }

        /// <summary>
        /// <see cref="OurMongosServer"/> enum ile <see cref="IMongoClient"/> döner.
        /// Dahili olarak <see cref="ResolveConnectionString"/> kullanır.
        /// </summary>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <returns>Cache'lenmiş MongoClient.</returns>
        public IMongoClient GetClient(OurMongosServer server)
        {
            return GetClient(ResolveConnectionString(server));
        }

        /// <summary>
        /// Belirtilen sunucu ve veritabanı için <see cref="IMongoDatabase"/> referansı döner.
        /// </summary>
        /// <param name="server">Hedef MongoDB sunucusu.</param>
        /// <param name="databaseName">Veritabanı adı.</param>
        /// <returns>MongoDB veritabanı referansı.</returns>
        public IMongoDatabase GetDatabase(OurMongosServer server, string databaseName)
        {
            return GetClient(server).GetDatabase(databaseName);
        }

        /// <summary>
        /// Custom connection string ile <see cref="IMongoDatabase"/> referansı döner.
        /// </summary>
        /// <param name="connectionString">MongoDB bağlantı dizesi.</param>
        /// <param name="databaseName">Veritabanı adı.</param>
        /// <returns>MongoDB veritabanı referansı.</returns>
        public IMongoDatabase GetDatabase(string connectionString, string databaseName)
        {
            return GetClient(connectionString).GetDatabase(databaseName);
        }
    }
}
