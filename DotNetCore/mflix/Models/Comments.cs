using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mflix.Models
{
    public class Comments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("movie_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Movie_Id { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        [BsonElement("date")]
        public BsonDateTime Date { get; set; }

    }
}