using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }

        [Required]
        public byte GenresId { get; set; }
        [Required(ErrorMessage = "The field Number in Stocke must be between 1 and 20")]

        [Range(1, 20)]
        public int Stock { get; set; }
    }
}