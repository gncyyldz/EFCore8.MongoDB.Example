using MongoDB.Driver;

namespace EFCore8.MongoDB.Example.Services
{
    public class MongoDBService
    {
        readonly IMongoDatabase _database;
        public MongoDBService(IConfiguration configuration)
        {
            MongoClient client = new("mongodb://localhost:27017");
            _database = client.GetDatabase("ExampleDB");
        }
        public IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }
}
