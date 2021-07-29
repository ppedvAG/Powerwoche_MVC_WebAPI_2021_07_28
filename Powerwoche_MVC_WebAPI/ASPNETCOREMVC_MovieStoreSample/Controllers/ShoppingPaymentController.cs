using ASPNETCOREMVC_MovieStoreSample.Data;
using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Controllers
{
    public class ShoppingPaymentController : Controller
    {

        private readonly MovieStoreDbContext _ctx;

        public ShoppingPaymentController(MovieStoreDbContext context)
        {
            _ctx = context;
        }

        public IActionResult ShoppingCartOverview()
        {
            List<Movie> movieList = new List<Movie>();

            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    movieList = InitializeShoppingCart();
                }
            }
            return View(movieList);
        }


        private List<Movie> InitializeShoppingCart()
        {
            List<Movie> movieList = new List<Movie>();

            string shoppingCartJsonString = HttpContext.Session.GetString("ShoppingCart");
            List<int> ids = JsonSerializer.Deserialize<List<int>>(shoppingCartJsonString);


            foreach (int currenctArticleId in ids)
            {
                Movie currentMovie = _ctx.Movies.Find(currenctArticleId);
                movieList.Add(currentMovie);
            }

            return movieList;
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            List<Movie> movies = InitializeShoppingCart();

            //Wird geprüft, ob die ArtikelId sich im Warenkorb befindet
            if (movies.Any(a => a.Id == id.Value))
            {
                Movie toCancel = movies.First(a => a.Id == id.Value);
                movies.Remove(toCancel);
            }

            if (movies.Count == 0)
            {
                HttpContext.Session.Remove("ShoppingCart");
            }
            else
            {
                string jsonString = JsonSerializer.Serialize(movies.Select(n => n.Id).ToList());

                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }

            return RedirectToAction(nameof(ShoppingCartOverview));
        }


    }
}
