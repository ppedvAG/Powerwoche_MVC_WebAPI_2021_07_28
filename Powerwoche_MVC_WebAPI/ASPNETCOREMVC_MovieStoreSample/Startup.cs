using ASPNETCOREMVC_MovieStoreSample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_MovieStoreSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            /// <summary>
            /// Adds MVC services to the specified <see cref="IServiceCollection" />.
            /// </summary>
            /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
            /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
            //public static IMvcBuilder AddMvc(this IServiceCollection services)
            //{
            //    if (services == null)
            //    {
            //        throw new ArgumentNullException(nameof(services));
            //    }

            //    services.AddControllersWithViews();
            //    return services.AddRazorPages();
            //}

            services.AddDbContext<MovieStoreDbContext>(options =>
            {
                //options.UseInMemoryDatabase("MovieStoreDb");
                options.UseSqlServer(Configuration.GetConnectionString("MovieStoreDB"));
            });

            services.AddAuthentication();
            
            services.AddSession();

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                     new CultureInfo("de"),
                     new CultureInfo("fr")
                };

                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseAuthentication(); //Steht vor Auth
            app.UseAuthorization();
            app.UseSession();

            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                     name: "movie",
                     pattern: "movie/{*movie}", defaults: new { controller = "Movie", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapDefaultControllerRoute(); -> beinhaltet die Default-Route 

                endpoints.MapRazorPages();
            });
        }
    }
}
