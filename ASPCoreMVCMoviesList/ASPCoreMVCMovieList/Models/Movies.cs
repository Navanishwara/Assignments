using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVCMovieList.Models
{
    [Table("movielist")]
    public class Movies
    {
        [Key]
        [Column("id")]
        public int id {get;set;}

        [Column("movie_name")]
        public string Movie_Name { get; set; }
        [Column("genre")]
        public string Genre { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("producer")]
        public string Producer { get; set; }
    }
}
