using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    { 
        public PaginatedList<Movie> movies;
        public IQueryable<LoadMovieRole> roles;
        public SelectList genres;
        public string movieGenre { get; set; }
    }
}