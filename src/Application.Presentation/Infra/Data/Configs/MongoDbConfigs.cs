namespace Conecta.Doa.Application.Presentation.Infra.Data.Configs;

public class MongoDbConfigs
{
    public string ConnectionString { get; init; }
    public string DatabaseName { get; init; }
    public MongoDbConfigs(string? connectionString, string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }
}
