using ASPCoreMVCMovieList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVCMovieList.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovie dal;


        public MovieController(IMovie dal)
        {
            this.dal = dal;
        }
        MovieVM movieVM = new MovieVM();
        public IActionResult Index()
        {
             
            movieVM.Movies = dal.GetAllMovies();

            return View(movieVM);
        }
        public IActionResult Create(Movies movies)
        {
            
            dal.AddMovies(movies);
            return RedirectToAction("Index");
        }
    }
}
