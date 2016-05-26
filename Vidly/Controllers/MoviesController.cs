using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        [Route("Movies")]
        public ActionResult Index()
        {
            var movie = new List<Movie>
            {
                new Movie { Name = "Shrek!" },
                new Movie {Name = "Batman"}

            };

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

   


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

    }
}