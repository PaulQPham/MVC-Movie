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
        //View used by Movies page and Actor details page to display roles
        public Movie movie;
        public Actor actor;
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string newRole { get; set; } //Field to create new MovieRole
        public string newMovie;             //Field to create new MovieRole
        public string newActor;             //Field to create new MovieRole
        public SelectList movies;           //Dropdown list to display movies on Actors edit page
        public SelectList actors;           //Dropdown list to display ACTORS on mOVIE edit page
        public IQueryable<LoadMovieRole> roles;
    }
}
