using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieRole //Model created from CSV data to use in DB
    {
        public int ID { get; set; }
        public string Character { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
    public class LoadMovieRole //Used to read in CSV data
    {
        public string Actor { get; set; }
        public string Character { get; set; }
        public string Movie { get; set; }
    }
}
