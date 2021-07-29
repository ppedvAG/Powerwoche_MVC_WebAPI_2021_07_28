using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            ViewData["abc"] = "Hallo liebe Teilnehmer";
            ViewData["def"] = "Auch das wird mit übergeben";

            return View(/* Wir könnten hier ein ViewModel Übertragen */);
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.GHJ = "Eigentlich verwende ich intern die ViewBag :-)";

            return View();
        }

        public IActionResult TempDataSample()
        {
            TempData["EmailAddress"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;
            return View();
        }
        public IActionResult TempDataSecondSample()
        {
            
            return View();
        }
        public IActionResult TempDataThirdSample()
        {
            return View();
        }


    }
}
