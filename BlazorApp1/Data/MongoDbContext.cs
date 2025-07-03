using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BlazorApp1.models;

namespace BlazorApp1.Data
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }
        public IMongoClient Client { get; }

        public MongoDbContext(IOptions<MongoDbConfig> config)
        {
            Client = new MongoClient(config.Value.ConnectionString);
            Database = Client.GetDatabase(config.Value.DatabaseName);
        }
    }
}

