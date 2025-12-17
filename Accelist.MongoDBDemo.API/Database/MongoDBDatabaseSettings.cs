namespace Accelist.MongoDBDemo.API.Database;

public class MongoDBDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public Dictionary<String, String> CollectionNames { get; set; } = new Dictionary<string, string>();
}
