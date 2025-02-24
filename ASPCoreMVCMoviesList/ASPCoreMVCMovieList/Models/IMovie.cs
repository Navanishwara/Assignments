namespace ASPCoreMVCMovieList.Models
{
    public interface IMovie
    {
       void AddMovies(Movies movies);   
        List<Movies> GetAllMovies();
    }
}
