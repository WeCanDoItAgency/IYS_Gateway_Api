using System;
using System.Collections.Concurrent;
using IYS.Gateway.Infrastructure.Mongo.Providers;
using IYS.Gateway.Infrastructure.Mongo.Settings;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    public class GenericMongoConnectionManager
    {
        private static readonly Lazy<GenericMongoConnectionManager> _instance = 
            new Lazy<GenericMongoConnectionManager>(() => new GenericMongoConnectionManager());

        public static GenericMongoConnectionManager Instance => _instance.Value;

        private readonly ConcurrentDictionary<string, IMongoClient> _clients = new();
        private bool _isSerializerRegistered = false;
        private readonly object _serializerLock = new object();

        private GenericMongoConnectionManager()
        {
            RegisterSerializers();
        }

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

        public IMongoClient GetClient(OurMongosServer server)
        {
            return GetClient(ResolveConnectionString(server));
        }

        public IMongoDatabase GetDatabase(OurMongosServer server, string databaseName)
        {
            return GetClient(server).GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase(string connectionString, string databaseName)
        {
            return GetClient(connectionString).GetDatabase(databaseName);
        }
    }
}
