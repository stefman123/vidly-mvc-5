using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
   

    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public MovieGenre Genres { get; set; }
        public byte GenresId { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }
    }
}