using ASPNETCOREMVC_MovieStoreSample.Data;
using ASPNETCOREMVC_MovieStoreSample.Filters;
using ASPNETCOREMVC_MovieStoreSample.Middleware;
using ASPNETCOREMVC_MovieStoreSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddMvc(options=> {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
                        "Result filter added to MvcOptions.Filters"));         // An instance
            });

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


            services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.StringPosition));

            
            services.AddScoped<MyActionFilterAttribute>();

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
            //MUSS-Reihenfolge:
            // - UseCors, UseAuthentication und UseAuthorization müssen in der angezeigten Reihenfolge stehen.
            // - UseCors muss derzeit aufgrund dieses Fehlers vor UseResponseCaching stehen.



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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);

            #region Customize Middleware einbindungen oder implementierung


            #region Sample1 - Use
            //app.Use(async (context, next) =>
            //{
            //    //Request Part Begin
            //    await context.Response.WriteAsync("Vor Invoke from 1st app.Use()\n");
            //    //Request Part End
            //    await next.Invoke(); //Rufe nächste Middleware auf
            //    //Response Part 
            //    await context.Response.WriteAsync("Nach Invoke from 1st app.Use()\n");
            //});
            //#endregion

            //#region Sample2 - Use
            //app.Use(async (context, next) =>
            //{
            //    //Request Part
            //    await context.Response.WriteAsync("Vor Invoke from 2nd app.Use()\n");
            //    await next.Invoke();
            //    //Response Part
            //    await context.Response.WriteAsync("Nach Invoke from 2nd app.Use()\n");
            //});
            //#endregion


            //#region Sample3 - Use
            //app.Use(async (context, next) =>
            //{
            //    //Request Part
            //    await context.Response.WriteAsync("Vor Invoke from 3nd app.Use()\n");
            //    await next.Invoke();
            //    //Response Part
            //    await context.Response.WriteAsync("Nach Invoke from 3nd app.Use()\n");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate.");
            //});
            #endregion



            #region Sample 2 - Map
            //Request                         Response
            //https://localhost:5001/        Hello from app.Run()
            //https://localhost:5001/m1      Hello from 1st app.Map()
            //https://localhost:5001/m1/xyz  Hello from 1st app.Map()
            //https://localhost:5001/m2      Hello from 2nd app.Map()
            //https://localhost:5001/m500    Hello from app.Run()


            //app.Map("/m1", HandleMapOne);
            //app.Map("/m2", appMap =>
            //{
            //    appMap.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from 2nd app.Map()");
            //    });
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from app.Run");
            //});
            #endregion


            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbnailGen();
            });




            #endregion





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


        private static void HandleMapOne(IApplicationBuilder app)
        {
            //Run Terminiert eine Middleware- Das Request wird nicht mehr weitergereicht 
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map");
            });
        }
    }
}
