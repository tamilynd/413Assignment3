using _413Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //grab context
        private MoviesDBContext _context;
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, MoviesDBContext context, IMovieRepository rep)
        {
            _logger = logger;
            _context = context;
            _repository = rep;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        //Returns the list of movies currently in the database
        public IActionResult MovieList()
        {
            IEnumerable<Movie> movies;

            movies = _context.Movies.OrderBy(m => m.Title);

            return View("MovieList", movies);
        }

        //Returns a thank you page after adding a movie
        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                
            }
            
            return View("ThankYou", movie);
        }

        //Returns a prefilled form that has all the current movie information
        [HttpPost]
        public IActionResult EditForm(int movieID)
        {
            IEnumerable<Movie> movie;
            movie = _repository.Movies.Where(b => b.MovieId == movieID);
            
            return View("EditForm", movie.First());

        }

        //Updates movie
        [HttpPost]
        public IActionResult MovieUpdate(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();

            IEnumerable<Movie> movies;

            movies = _context.Movies.OrderBy(m => m.Title);

            return View("movieList", movies);
        }

        //Deletes Movie that the user selects
        [HttpPost]
        public IActionResult DeleteMovie(int movieID)
        {
            IEnumerable<Movie> movie;

            movie = _repository.Movies.Where(b => b.MovieId == movieID);

            _context.Remove(movie.First());
            _context.SaveChanges();

            IEnumerable<Movie> movies;

            movies = _context.Movies.OrderBy(m => m.Title);

            return View("movieList", movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
