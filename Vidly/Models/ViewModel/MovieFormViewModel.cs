using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models.EntryModel;
using Vidly.Models.EntryModel.SeedModel;

namespace Vidly.Models.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
         public string Title
        {
             get
            {
                 if (Movie != null && Movie.Id != 0)
                       return "Edit Movie";
 
                return "New Movie";
             }
         }
    }
}