using ASPNETCOREMVC_RazorSamples.Models;
using ASPNETCOREMVC_RazorSamples.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_RazorSamples.Controllers
{
    public class TableSampleController : Controller
    {
        public IActionResult Index()
        {
            IList<Movie> movies = new List<Movie>();
            movies.Add(new Movie
            {
                Id = 1,
                Title = "ES",
                Desciption = "Verwirrter Clown muss zum Zahnarzt"
            });

            movies.Add(new Movie
            {
                Id = 2,
                Title = "Star Wars 10",
                Desciption = "Die Niederlage der JavaScript Entwickler"
            });

            movies.Add(new Movie
            {
                Id = 3,
                Title = "Star Wars 11",
                Desciption = ".NET Imperium schlägt zurück"
            });


            return View(movies);
        }


        public IActionResult ViewModelAndTableSample()
        {
            RegisseurStatVM vm = new RegisseurStatVM();
            vm.MovieList = new List<Movie>();
            vm.FourivteActors = new List<Actors>();
            vm.Regisseur = new Regisseur() { Id = 1, Name = "Steven Spielberg" };


            vm.MovieList.Add(new Movie
            {
                Id = 1,
                Title = "ES",
                Desciption = "Verwirrter Clown muss zum Zahnarzt"
            });

            vm.MovieList.Add(new Movie
            {
                Id = 2,
                Title = "Star Wars 10",
                Desciption = "Die Niederlage der JavaScript Entwickler"
            });

            vm.MovieList.Add(new Movie
            {
                Id = 3,
                Title = "Star Wars 11",
                Desciption = ".NET Imperium schlägt zurück"
            });

            return View(vm);
        }
    }
}
