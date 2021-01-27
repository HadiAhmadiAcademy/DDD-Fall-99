using MongoDB.Driver;

namespace Scoring.Infrastructure.Persistence.Mongo
{
    public static class MongoDatabaseFactory
    {
        public static IMongoDatabase CreateDatabase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}