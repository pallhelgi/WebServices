using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mflix.Models
{
    [BsonIgnoreExtraElements]
    public class Sessions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("user_id")]
        public string User_Id { get; set; }
        [BsonElement("jwt")]
        public string Jwt { get; set; }
    }
}