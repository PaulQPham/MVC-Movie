using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieRole
    {
        public int ID { get; set; }
        public string Actor { get; set; }
        public string Character { get; set; }
        public string Movie { get; set; }
    }
}
