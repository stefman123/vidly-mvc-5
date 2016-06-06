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
        [Display(Name = "Genre")]
        public MovieGenre Genres { get; set; }
        [Required]
        public byte GenresId { get; set; }
        [Required(ErrorMessage = "The field Number in Stocke must be between 1 and 20" )]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        
        public int Stock { get; set; }
    }
}