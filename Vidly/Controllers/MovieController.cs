using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies



        //[Route("Movies")]
        public ActionResult Index()
        {
            //var movie = new List<Movie>
            //{
            //    new Movie { Name = "Shrek!" },
            //    new Movie {Name = "Batman"}

            //};

          //var movies = _context.Movies.Include(g => g.Genres).ToList();

          //  return View(movies);

            //implimenting authorization at the role level
            if (User.IsInRole(RoleName.CanManageMovies))
               return View("List"); 
      
          return View("ReadOnlyList");        
        }

        public ActionResult MovieDetails(int id)
        {
          var movie = _context.Movies.Include(g => g.Genres).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }


        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};

        var customers = new List<Customer>
        {
            new Customer {Name = "Customer 1"},
            new Customer { Name = "Customer 2"}
        };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movieGenreList = _context.MovieGenres.ToList();

            var movie = new MovieFormViewModel
            {
                //Movie = new Movie(),
                MovieGenres = movieGenreList

            };

            return View("MovieForm",movie);

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
           var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
             
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModal = new MovieFormViewModel(movie)
                {
                    //Movie = new Movie(),
                    MovieGenres = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewModal);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenresId = movie.GenresId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}