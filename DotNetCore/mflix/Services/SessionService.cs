using mflix.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace mflix.Services
{
    public class SessionService
    {
        private readonly IMongoCollection<Sessions> _sessions;

        public SessionService(IMflixDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sessions = database.GetCollection<Sessions>(settings.SessionsCollectionName);
        }

        public List<Sessions> Get() =>
            _sessions.Find(session => true).ToList();

        public Sessions Get(string id) =>
            _sessions.Find<Sessions>(session => session.Id == id).FirstOrDefault();

        public Sessions Create(Sessions session)
        {
            _sessions.InsertOne(session);
            return session;
        }

        public void Update(string id, Sessions sessionIn) =>
            _sessions.ReplaceOne(session => session.Id == id, sessionIn);

        public void Remove(Sessions sessionIn) =>
            _sessions.DeleteOne(session => session.Id == sessionIn.Id);

        public void Remove(string id) =>
            _sessions.DeleteOne(session => session.Id == id);
    }
}