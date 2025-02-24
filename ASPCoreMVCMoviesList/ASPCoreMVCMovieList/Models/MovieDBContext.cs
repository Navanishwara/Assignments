using Microsoft.EntityFrameworkCore;

namespace ASPCoreMVCMovieList.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions opts) : base(opts)   
        {
            
        }
        public DbSet<Movies> MovieList { get; set; }   
    }
}
