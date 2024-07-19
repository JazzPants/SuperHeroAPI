using SuperHeroAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace SuperHeroAPI.Services
{
    public class MongoDBService
    {

        private readonly IMongoCollection<Superhero> _superheroCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _superheroCollection = database.GetCollection<Superhero>(mongoDBSettings.Value.CollectionName);
        }

    }
}
