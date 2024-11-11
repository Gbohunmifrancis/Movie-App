using Microsoft.AspNetCore.Mvc;
using Movie_App.Services;
using Movie_App.Models.DTO;
using System.Threading.Tasks;

namespace Movie_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieService _movieService;

        public HomeController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Fetch the popular movies
                var movies = await _movieService.GetPopularMoviesAsync();

                // Check if no movies are found
                if (movies == null || movies.Count == 0)
                {
                    TempData["ErrorMessage"] = "No movies found at the moment. Please try again later.";
                    return View(new List<MovieDto>());
                }

                return View(movies);
            }
            catch (Exception ex)
            {
                // Log the exception (you can implement a logger here)
                TempData["ErrorMessage"] = "An error occurred while fetching movies. Please try again later.";
                return View(new List<MovieDto>());
            }
        }
    }
}