using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewHostingAPIsSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHostingAPIsSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDBContext _context;
        public PeopleController(PeopleDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPeople ()
        {
            return Ok(_context.Persons.ToList());
        }
    }
}
