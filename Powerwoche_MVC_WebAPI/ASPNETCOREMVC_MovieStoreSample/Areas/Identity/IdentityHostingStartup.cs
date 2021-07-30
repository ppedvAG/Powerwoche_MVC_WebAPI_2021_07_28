using System;
using ASPNETCOREMVC_MovieStoreSample.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPNETCOREMVC_MovieStoreSample.Areas.Identity.IdentityHostingStartup))]
namespace ASPNETCOREMVC_MovieStoreSample.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASPNETCOREMVC_MovieStoreSampleContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASPNETCOREMVC_MovieStoreSampleContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ASPNETCOREMVC_MovieStoreSampleContext>();
            });
        }
    }
}