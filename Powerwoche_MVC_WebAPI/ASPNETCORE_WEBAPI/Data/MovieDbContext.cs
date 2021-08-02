using ASPNETCORE_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI.Data
{
    public class MovieDbContext : DbContext
    {

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
