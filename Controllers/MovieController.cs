using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyCore.Models;
using VidlyCore.ViewModels;

namespace VidlyCore.Controllers
{
    public class MovieController : Controller
    {
        public readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreType).ToList();
            return View(movies);
        }

        public IActionResult New()
        {
            var movieViewModel = new MovieViewModel()
            {
                Movie = new Movie() {DateAdded = DateTime.Now },
                GenreType = _context.GenreTypes.ToList()

            };
            return View("MovieForm", movieViewModel);
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var movieViewModel = new MovieViewModel()
            {
                Movie = movie,
                GenreType = _context.GenreTypes.ToList()
            };
            return View("MovieForm", movieViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieViewModel = new MovieViewModel()
                {
                    Movie = movie,
                    GenreType = _context.GenreTypes.ToList()
                };
                return View("MovieForm", movieViewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberOfMoviesInStock = movie.NumberOfMoviesInStock;
            }


            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var FoundMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (FoundMovie != null)
            {
                var movieViewModel = new MovieViewModel()
                {
                    Movie = FoundMovie,
                    GenreType = _context.GenreTypes.ToList()
                };
                return View("Delete", movieViewModel);
            }
            else
            {
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MovieViewModel viewModel)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == viewModel.Movie.Id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
