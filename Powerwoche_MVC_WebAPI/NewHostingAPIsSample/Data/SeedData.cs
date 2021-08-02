using NewHostingAPIsSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHostingAPIsSample.Data
{
    public class SeedData
    {
        public static void Initialize(PeopleDBContext ctx)
        {
            if (!ctx.Persons.Any())
            {
                ctx.Persons.Add(new Person() { Id = 1, Firstname = "Hannes", Lastname = "Preishuber" });
                ctx.Persons.Add(new Person() { Id = 2, Firstname = "Andre", Lastname = "Ruland" });
                ctx.Persons.Add(new Person() { Id = 3, Firstname = "Kevin", Lastname = "Winter" });
                ctx.SaveChanges();
            }
        }
    }
}
