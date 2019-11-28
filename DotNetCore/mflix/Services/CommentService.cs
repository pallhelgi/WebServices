using mflix.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace mflix.Services
{
    public class CommentService
    {
        private readonly IMongoCollection<Comments> _comments;

        public CommentService(IMflixDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _comments = database.GetCollection<Comments>(settings.CommentsCollectionName);
        }

        public List<Comments> Get() =>
            _comments.Find(comment => true).ToList();

        public Comments Get(string id) =>
            _comments.Find<Comments>(comment => comment.Id == id).FirstOrDefault();

        public Comments Create(Comments comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }

        public void Update(string id, Comments commentIn) =>
            _comments.ReplaceOne(comment => comment.Id == id, commentIn);

        public void Remove(Comments commentIn) =>
            _comments.DeleteOne(comment => comment.Id == commentIn.Id);

        public void Remove(string id) =>
            _comments.DeleteOne(comment => comment.Id == id);
    }
}