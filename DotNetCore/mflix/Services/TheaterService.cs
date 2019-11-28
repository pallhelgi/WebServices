using mflix.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace mflix.Services
{
    public class TheaterService
    {
        private readonly IMongoCollection<Theaters> _theaters;

        public TheaterService(IMflixDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _theaters = database.GetCollection<Theaters>(settings.TheatersCollectionName);
        }

        public List<Theaters> Get() =>
            _theaters.Find(theater => true).ToList();

        public Theaters Get(string id) =>
            _theaters.Find<Theaters>(theater => theater.Id == id).FirstOrDefault();

        public Theaters Create(Theaters theater)
        {
            _theaters.InsertOne(theater);
            return theater;
        }

        public void Update(string id, Theaters theaterIn) =>
            _theaters.ReplaceOne(theater => theater.Id == id, theaterIn);

        public void Remove(Theaters theaterIn) =>
            _theaters.DeleteOne(theater => theater.Id == theaterIn.Id);

        public void Remove(string id) =>
            _theaters.DeleteOne(theater => theater.Id == id);
    }
}