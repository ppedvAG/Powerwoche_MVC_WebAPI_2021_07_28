using ASPNETCORE_WEBAPI.Data;
using ASPNETCORE_WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatterController : ControllerBase
    {
        private readonly MovieDbContext _ctx;
        public FormatterController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("GetMovieString")]
        public string GetMovieString() //gibt nur string aus, kein json
        {
            Movie currentMovie = _ctx.Movies.First();
            return $"Id: {currentMovie.Id} Name: {currentMovie.Title}";
        }

        [HttpDelete("About")]
        public ContentResult About() //ContentResult liefer string (kein json)
        {
            return Content("An API listing authors of docs.asp.net.");
        }

        [HttpGet("Search")]
        //Call -> https://localhost:5001/api/Formatter/Search?namelike=Star
        public IActionResult Search(string namelike)
        {
            var result = _ctx.Movies.Where(m => m.Title.Contains(namelike)).ToList();

            if (!result.Any())
            {
                return NotFound(namelike);
            }

            return Ok(result);
            //content-type: application/json; charset=utf-8 
        }


        #region Zuordnung des Antwortformats durch URLs

        ///api/Formatter/5	  Standard-Ausgabeformatierungsprogramm
        ///api/Formatter/5.json JSON-Formatierungsprogramm (falls konfiguriert)
        //api/Formatter/5.xml   XML-Formatierungsprogramm  (falls konfiguriert

        [HttpGet("{id}.{format?}")]
        public Movie Get(int id)
        {


            return new Movie();
        }
        #endregion
    }
}
