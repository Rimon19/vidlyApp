using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.EntryModel.SeedModel;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
 
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
 
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
 
        public byte NumberInStock { get; set; }
    }
}