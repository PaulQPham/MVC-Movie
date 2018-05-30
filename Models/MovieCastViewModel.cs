using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieCastViewModel
    {
        public Movie movie;
        public Actor actor;
        public IQueryable<LoadMovieRole> roles;
    }
}
