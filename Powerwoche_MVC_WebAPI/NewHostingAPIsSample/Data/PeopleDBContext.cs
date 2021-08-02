using Microsoft.EntityFrameworkCore;
using NewHostingAPIsSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHostingAPIsSample.Data
{
    public class PeopleDBContext :DbContext
    {
        public PeopleDBContext(DbContextOptions<PeopleDBContext> options)
            :base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
