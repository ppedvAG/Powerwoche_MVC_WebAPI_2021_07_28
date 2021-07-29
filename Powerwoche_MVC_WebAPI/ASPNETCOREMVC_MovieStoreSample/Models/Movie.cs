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

        [Required (AllowEmptyStrings = false, ErrorMessage = "Bitte geben einen Titel ein")]
        public string Title { get; set; }

        [MaxLength(75, ErrorMessage = "Max 75 Zeichen")]
        public string Desciption { get; set; }

       public decimal Preis { get; set; }
    }
}
