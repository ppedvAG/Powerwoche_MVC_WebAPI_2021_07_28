using DependencyInjection_Sample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_Intro.Controllers
{
    public class MyFirstController : Controller //DefaultControllerFactory
    {
        private readonly ICar _car;

        public MyFirstController(ICar car) //Seperation of Concern 
        {
            _car = car;      
        }
        public IActionResult Index()
        {
            return View(_car);
        }
    }
}
