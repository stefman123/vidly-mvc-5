using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public byte? GenresId { get; set; }

        [Required(ErrorMessage = "The field Number in Stocke must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]

        public int? Stock { get; set; }

        public IEnumerable<MovieGenre> MovieGenres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        //used when creating a new movie
        public MovieFormViewModel()
        {
            // make sure hidden filed in form is populated
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenresId = movie.GenresId;

        }
    }
}