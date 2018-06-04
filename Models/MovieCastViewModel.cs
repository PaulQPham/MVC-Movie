using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieCastViewModel
    {
        public Movie movie;
        public Actor actor;
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string newRole;
        public string newMovie;
        public SelectList movies;
        public IQueryable<LoadMovieRole> roles;
    }
}
