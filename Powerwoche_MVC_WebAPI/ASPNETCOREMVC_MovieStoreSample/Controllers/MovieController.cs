using ASPNETCOREMVC_MovieStoreSample.Data;
using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieStoreDbContext _context;

        public MovieController(MovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                ViewData["FilterQuery"] = query;
            }

            IList<Movie> filteredList = string.IsNullOrEmpty(query) ?
                await _context.Movies.ToListAsync() :
                await _context.Movies.Where(q => q.Title.Contains(query)).ToListAsync();

            return View(filteredList);
        }


        [HttpGet("/movie/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("/movie/create/{id?}")]
        public IActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost("/movie/create")]
         [AutoValidateAntiforgeryToken]
         public async Task<IActionResult> Create(Movie movie)
         {

            if (movie.Title == "Basic Instinkt")
            {
                ModelState.AddModelError("Title", "Achtung vor Sharon!");
            }

            if (ModelState.IsValid) //Serverseitige Validierung
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
         }

        [HttpGet("/movie/details/{id}")]
        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Movie currentMovie = await _context.Movies.FindAsync(Id.Value);


            return View(currentMovie);
        }



        [HttpPost("/movie/buy/{id}")]
        public IActionResult Buy(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();


            //Hier kommt noch Logik dazu
            if (HttpContext.Session.IsAvailable)
            {
                List<int> idList = new List<int>();

                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    //Wenn ja, wurde schon einmal was gekauft und der Session-Eintrag exisitiert
                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

                    //befüllte idList mit existierenden Einkäufe
                    idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
                }


                idList.Add(Id.Value);

                string jsonString = JsonSerializer.Serialize(idList);

                HttpContext.Session.SetString("ShoppingCart", jsonString);

            }
            
            
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("/movie/Sample1")]
        public IActionResult Sample1()
        {
            return View();
        }

        [HttpPost("/movie/Sample1")]
        public IActionResult Sample1(string myText, int myNumber)
        {
            return RedirectToAction("Sample2", new { myText = myText, myNumber = myNumber });
        }
        [HttpGet("/movie/Sample2/{myText}/{myNumber}")]
        public IActionResult Sample2 (string myText, int myNumber)
        {
            MyLinkValues values = new();

            values.Name = myText;
            values.Zahl = myNumber;

            return View(values);
        }

        [HttpGet("/movie/Sample3")]
        public IActionResult Sample3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAny(string myText, int MyNumber)
        {

            //Füge deine Logik ein!!!
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DoAnything(string myText, int MyNumber)
        {
            //Füge deine Logik ein!!!
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sample3(string myText, int myNumber) //Parametervarialen müssen den selbe Benennung aufweisen, wie in  <input>-Tag - Attribut Name: 
        {

            return RedirectToAction("Sample2", new { myText = myText, myNumber = myNumber });
        }

    }

    public class MyLinkValues // Modelklasse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zahl { get; set; }
    }
}
