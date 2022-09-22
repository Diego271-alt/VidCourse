using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VidCourse.Models;
using VidCourse.ViewModels;
using System.Data.Entity;
using System.Xml.Linq;

namespace VidCourse.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int Id)
        {
            //
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }




        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name="Sherk"
            };

            var customer = new List<Customer>
        {
            new Customer{Name="Customer 1"},
            new Customer{Name="Customer 2"}
        };
            var viewModel = new RandomViewModel
            {
                Movie=movie,
                Customer=customer
            };

            return View(viewModel);
        }

  

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
      


            if (movie.Id == 0)
            {
                //var newMovie = new Movie();
                //newMovie.DateAdded = DateTime.Now;
                //newMovie.Name = movie.Name;
                //newMovie.GenreId = movie.GenreId;
                //newMovie.NumberInStock = movie.NumberInStock;
                //newMovie.ReleaseDate = movie.ReleaseDate;
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

  
        //[Route("movies/released/{year}/{month}")]
        /*public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }*/
        /*
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }*/

    }
}