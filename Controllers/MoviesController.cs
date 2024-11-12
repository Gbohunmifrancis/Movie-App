using Microsoft.AspNetCore.Mvc;
using Movie_App.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movie_App.Models.DTO;

namespace Movie_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private const int DefaultPageSize = 10; // Default items per page

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = DefaultPageSize)
        {
            try
            {
                // Fetch all popular movies
                var allMovies = await _movieService.GetPopularMoviesAsync();

                // Check if no movies are found
                if (allMovies == null || allMovies.Count == 0)
                {
                    TempData["ErrorMessage"] = "No movies found at the moment. Please try again later.";
                    return View(new List<MovieDto>());
                }

                // Calculate total pages for pagination
                int totalMovies = allMovies.Count;
                int totalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);

                // Ensure the page is within bounds
                page = Math.Max(1, Math.Min(page, totalPages));

                // Get movies for the current page
                var movies = allMovies
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Pass pagination data to the view
                ViewBag.TotalPages = totalPages;
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

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
