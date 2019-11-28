using mflix.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace mflix.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movies> _movies;

        public MovieService(IMflixDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movies = database.GetCollection<Movies>(settings.MoviesCollectionName);
        }

        public List<Movies> Get() =>
            _movies.Find(movie => true).ToList();

        public Movies Get(string id) =>
            _movies.Find<Movies>(movie => movie.Id == id).FirstOrDefault();

        public Movies Create(Movies movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movies movieIn) =>
            _movies.ReplaceOne(movie => movie.Id == id, movieIn);

        public void Remove(Movies movieIn) =>
            _movies.DeleteOne(movie => movie.Id == movieIn.Id);

        public void Remove(string id) =>
            _movies.DeleteOne(movie => movie.Id == id);
    }
}