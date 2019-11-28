using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mflix.Models
{
    [BsonIgnoreExtraElements]
    public class Theaters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("theaterid")]
        public int TheaterId { get; set; }
        [BsonElement("location")]
        public Location Location { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Location
    {
        [BsonElement("address")]
        public Address Address { get; set; }
        [BsonElement("geo")]
        public Geo Geo { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Address
    {
        [BsonElement("street1")]
        public string Street1 { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("zipcode")]
        public string ZipCode { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Geo
    {
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}