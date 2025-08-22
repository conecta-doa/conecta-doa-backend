using Conecta.Doa.Application.Presentation.Data.Configs;
using Conecta.Doa.Application.Presentation.Data.Interfaces;
using MongoDB.Driver;

namespace Conecta.Doa.Application.Presentation.Data.Context;

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;
    private readonly MongoDbConfigs _mongoDbConfigs;

    public IClientSessionHandle Session { get; set; }

    public MongoContext(MongoDbConfigs mongoDbConfigs)
    {
        _mongoDbConfigs = mongoDbConfigs;

        var mongoClient = new MongoClient(_mongoDbConfigs.ConnectionString);

        _database = mongoClient.GetDatabase(_mongoDbConfigs.DatabaseName);
    }

    public IMongoCollection<T> Collection<T>()
    {
        return _database.GetCollection<T>(typeof(T).Name);
    }

    public void Dipose()
    {
        Session?.Dispose();

        GC.SuppressFinalize(this);
    }
}
