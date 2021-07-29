using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample.Data
{
    public class MovieStoreDbContext :DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieSales> MovieSales { get; set; }
    }
}
