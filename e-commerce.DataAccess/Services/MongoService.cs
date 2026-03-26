using e_commerce.DataAccess.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace e_commerce.Services
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;
        public MongoService(IOptions<MongoSettings> settings)
        {
            MongoClient client = new(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
