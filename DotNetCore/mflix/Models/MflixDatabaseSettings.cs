namespace mflix.Models
{
    public class MflixDatabaseSettings : IMflixDatabaseSettings
    {
        public string CommentsCollectionName { get; set; }
        public string MoviesCollectionName { get; set; }
        public string SessionsCollectionName { get; set; }
        public string TheatersCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMflixDatabaseSettings
    {
        string CommentsCollectionName { get; set; }
        string MoviesCollectionName { get; set; }
        string SessionsCollectionName { get; set; }
        string TheatersCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}