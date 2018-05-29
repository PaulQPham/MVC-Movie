using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Actor
    {
        [Key]
        public int ActorsID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Hometown { get; set; }
        public string BirthName { get; set; }

        public List<MovieRole> MovieRoles { get; set; }
    }
}
