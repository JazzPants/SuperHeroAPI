using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace SuperHeroAPI.Models
{
    public class Superhero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;
        
        public string SuperPower { get; set; } = null!;
        
        public string Location { get; set; } = null!;

        [BsonElement("Items")]
        [JsonPropertyName("Items")]
        public List<string> Images { get; set; } = null!;
    }
}
