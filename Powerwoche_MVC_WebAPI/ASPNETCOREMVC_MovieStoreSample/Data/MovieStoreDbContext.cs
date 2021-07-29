using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCOREMVC_MovieStoreSample.Controllers;

namespace ASPNETCOREMVC_MovieStoreSample.Data
{
    public class MovieStoreDbContext :DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
