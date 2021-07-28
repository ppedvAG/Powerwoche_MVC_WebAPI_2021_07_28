using ASPNETCOREMVC_RazorSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_RazorSamples.ViewModels
{
    public class RegisseurStatVM
    {
        public Regisseur Regisseur { get; set; }
        public IList<Movie> MovieList { get; set; }
        public IList<Actors> FourivteActors { get; set; }
    }
}
