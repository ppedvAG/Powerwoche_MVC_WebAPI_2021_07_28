using ASPNETCOREMVC_RazorSamples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_RazorSamples.Controllers
{
    public class RazorSyntaxSamplesController : Controller
    {
        public IActionResult Index()
        {
            IList<Person> myPersons = new List<Person>();
            myPersons.Add(new Person("Max", 33));
            myPersons.Add(new Person("Moritz", 34));
            return View(myPersons.ToArray());
        }


        public IActionResult TagHelperSample()
        {
            return View();
        }

        public IActionResult CustomizeTagHelperSample()
        {
            return View();
        }


    }
}
