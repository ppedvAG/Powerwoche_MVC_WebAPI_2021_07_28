using ASPNETCOREMVC_MovieStoreSample.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Controllers
{
    //[AddHeader("Author", "Rick Anderson")]
    public class FilterSampleController : Controller
    {
        [ServiceFilter(typeof(MyActionFilterAttribute))]
        public IActionResult Index()
        {
            return View();
        }

        [Filters.Authorize("Read")]
        public IActionResult Read()
        {
            return View();
        }

        [Filters.Authorize("Write")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
