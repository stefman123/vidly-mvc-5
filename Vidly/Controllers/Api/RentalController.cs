using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.Internal;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult AddRental(RentalDto newRental)
        {
            ////Defensive Programming => for public api and when sharing code with multiple teams     

            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("MovieIds are incorrect");
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid");

            //var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            //foreach (Movie movie in movies)
            //{
            //    if (movie.AvailableStock == 0)
            //        return BadRequest("Movie is not available.");

            //    var rental = new Rental
            //        {
            //            Customers = customer,
            //            Movies = movie,
            //            DateRented = DateTime.Now
            //        };

            //        movie.AvailableStock--;

            //        _context.Rentals.Add(rental);

            //}

            //_context.SaveChanges();

            //return Ok();


            //Optimistic

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie movie in movies)
            {
                if (movie.AvailableStock == 0)
                    return BadRequest("Movie is not available.");

                var rental = new Rental
                {
                    Customers = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };

                movie.AvailableStock--;

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
