using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Models
{
    //View used on movie page to display roles and genres not in Movie model
    public class MovieGenreViewModel
    { 
        public PaginatedList<Movie> movies;
        public IQueryable<LoadMovieRole> roles;
        public SelectList genres;
        public Movie selectedMovie;
        public string movieGenre { get; set; }
    }
}