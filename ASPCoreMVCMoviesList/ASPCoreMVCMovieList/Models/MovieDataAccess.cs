

namespace ASPCoreMVCMovieList.Models
{
    public class MovieDataAccess : IMovie
    {
        private readonly MovieDBContext dbCtx;
        public MovieDataAccess(MovieDBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public void AddMovies(Movies movies)
        {
          
            dbCtx.MovieList.Add(movies);
            dbCtx.SaveChanges();
        }

        public List<Movies> GetAllMovies()
        {
            return dbCtx.MovieList.ToList();
        }
    }
}
