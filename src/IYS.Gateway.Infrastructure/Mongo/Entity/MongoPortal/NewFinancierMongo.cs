using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("NewFinancier")]
[BsonIgnoreExtraElements]
public class NewFinancierMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    [BsonExtraElements]
    public BsonDocument? ExtraElements { get; set; }
}
