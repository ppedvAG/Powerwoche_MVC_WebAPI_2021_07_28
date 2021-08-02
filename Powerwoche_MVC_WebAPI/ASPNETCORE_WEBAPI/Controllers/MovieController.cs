using ASPNETCORE_WEBAPI.Data;
using ASPNETCORE_WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

;

namespace ASPNETCORE_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _ctx;

        public MovieController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        //Minimale Anforderung, die Microsoft einen Programmierer abverlangt
        //Methoden Namen muss Get/Post/Delete/Put im MethodenNamen verwenden. 

        //[HttpGet]
        public List<Movie> GetAll()
        {
            return _ctx.Movies.ToList();
        }

    }
}
