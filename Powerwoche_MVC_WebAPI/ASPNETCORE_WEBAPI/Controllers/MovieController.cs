using ASPNETCORE_WEBAPI.Data;
using ASPNETCORE_WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ASPNETCORE_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/xml")]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _ctx;

        public MovieController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        //Minimale Anforderung, die Microsoft einen Programmierer abverlangt
        //Methoden Namen muss Get/Post/Delete/Put im MethodenNamen verwenden. 



        //Swagger kann nicht ohne HTTP-Verbs (Swagger-Konvention)
        /// <summary>
        /// [HttpGet("GetAll")] -> GetAll, gilt als Alias um eine doppelte Get-Belegung auf einer URL zu vermeiden. 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }

        [HttpGet("GetMoviesWithPagging/{pagingNumber}/{pagingSize}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesWithPagging(int pagingNumber, int pagingSize)
        {
            List<Movie> result = await _ctx.Movies.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToListAsync();
            return result;
        }


        [HttpGet("AllComedyMovies")] //-> AllComedyMovies, gilt als Alias um eine doppelte Get-Belegung auf einer URL zu vermeiden.
        public List<Movie> GetAllComeyMovies()
        {
            return _ctx.Movies.Where(n => n.Genre == Genre.Comedy).ToList();
        }

        [HttpGet("{id:int}")] // {id:int} sagt, dass eine Id exisiteren muss (keine nullable toleranz) + Constraint ist ein integer = Id muss vom Typ integeser sein
        public IActionResult GetById(int id)
        {
            if (id == default(int))
                return BadRequest("Id hat den Wert: " + id.ToString());

            Movie currentMovie = _ctx.Movies.Find(id);

            if (currentMovie == null)
                return BadRequest("Used Key " + id.ToString());

            return Ok(currentMovie);
        }

        [HttpPost]
        [HttpPut]
        public IActionResult MoviePost(Movie movie)
        {
            if (movie == null)
                return BadRequest();

            if (ModelState.IsValid)
            {


                if (movie.Id == default(int))
                {
                    _ctx.Movies.Add(movie);
                }
                else
                {
                    _ctx.Update(movie);
                }
                _ctx.SaveChangesAsync();
                return Ok();


            }

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult MovieDelete(int? id)
        {
            Movie currentMovie = _ctx.Movies.Find(id.Value);
            _ctx.Movies.Find(currentMovie);
            _ctx.SaveChangesAsync();

            return Ok();
        }
    }
}
