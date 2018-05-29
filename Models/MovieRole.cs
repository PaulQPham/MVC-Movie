using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieRole
    {
        public int ID { get; set; }
        public string Character { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
    public class LoadMovieRole
    {
        public string Actor { get; set; }
        public string Character { get; set; }
        public string Movie { get; set; }
    }
}
