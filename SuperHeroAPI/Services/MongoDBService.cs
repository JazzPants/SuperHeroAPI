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

        public async Task<List<Superhero>> GetSuperheroesAsync()
        {
            return await _superheroCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Superhero> GetSuperheroAsync(string id)
        {
            return await _superheroCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateSuperHeroAsync(Superhero superhero)
        {
            await _superheroCollection.InsertOneAsync(superhero);
            return;
        }

        public async Task UpdateSuperheroAsync(string id, Superhero updatedSuperhero)
        {
            await _superheroCollection.ReplaceOneAsync(x => x.Id == id, updatedSuperhero);
            return;
        }

        public async Task DeleteSuperHeroAsync(string id)
        {
            await _superheroCollection.DeleteOneAsync(x => x.Id == id);
            return;
        }

    }
}
