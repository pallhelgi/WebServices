using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace mflix.Models
{
    [BsonIgnoreExtraElements]
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("plot")]
        public string Plot { get; set; }
        [BsonElement("geners")]
        public List<string> Genres { get; set; }
        [BsonElement("runtime")]
        public double Runtime { get; set; }
        [BsonElement("cast")]
        public List<string> Cast { get; set; }
        [BsonElement("num_mflix_comments")]
        public int NumMflixComments { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("fullplot")]
        public string Fullplot { get; set; }
        [BsonElement("countries")]
        public List<string> Countries { get; set; }
        [BsonElement("released")]
        public BsonDateTime Released { get; set; }
        [BsonElement("directors")]
        public List<string> Directors { get; set; }
        [BsonElement("rated")]
        public string Rated { get; set; }
        [BsonElement("awards")]
        public Awards Awards { get; set; }
        [BsonElement("lastupdated")]
        public BsonDateTime Lastupdated { get; set; }
        [BsonElement("year")]
        public int Year { get; set; }
        [BsonElement("imdb")]
        public Imdb Imdb { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("tomatoes")]
        public Tomatoes Tomatoes { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class Awards
    {
        [BsonElement("wins")]
        public int Wins { get; set; }
        [BsonElement("nominations")]
        public int Nominatinos { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Imdb
    {
        [BsonElement("rating")]
        public double Rating { get; set; }
        [BsonElement("votes")]
        public int Votes { get; set; }
        [BsonElement("id")]
        public int Id { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Tomatoes
    {
        [BsonElement("viewer")]
        public Viewer Viewer { get; set; }
        [BsonElement("lastupdated")]
        public BsonDateTime Lastupdated { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Viewer
    {
        [BsonElement("rating")]
        public int Rating { get; set; }
        [BsonElement("numReviews")]
        public int NumReviews { get; set; }
        [BsonElement("meter")]
        public int Meter { get; set; }
    }
}