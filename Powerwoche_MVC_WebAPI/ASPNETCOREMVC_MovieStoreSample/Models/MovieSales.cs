using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Models
{
    public class MovieSales
    {
        public int Id { get; set; }

        [Required]
        public MediaType Media { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }
    }


    public enum MediaType { VHS=1, DVD, BlueRay, OnDemand}
}
