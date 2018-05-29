using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Hometown { get; set; }
        public string BirthName { get; set; }
        public virtual ICollection<MovieRole> Roles { get; set; }
    }
}
