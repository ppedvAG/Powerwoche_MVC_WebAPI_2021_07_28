using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(75)]
        public string Desciption { get; set; }

        public ICollection<MovieSales> MovieSales { get; set; }
    }
}
