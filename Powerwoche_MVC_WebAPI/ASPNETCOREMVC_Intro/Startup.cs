using ASPNETCOREMVC_Intro.Models;
using DependencyInjection_Sample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace ASPNETCOREMVC_Intro
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //geladene AppSettings 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //ServiceCollection ist Inversion of Controll - Container
        {
            services.AddControllersWithViews()//MVC wird hier verwendet -> Konvention -> Es wird ein Controller und View Verzeichnis erwartet
                .AddRazorRuntimeCompilation();  //Wird benötigt für die Library LiveReload von Westwind 

            //services.AddRazorPages(); //RazorPage - Konvention -> Es wird das Verzeichnis Pages verwendet

            //services.AddControllers(); //WebAPI -Y Konventionen -> Wird ein Controller Verzeichnis erwartet. 

            //services.AddMvc(); //Intern wird AddControllersWithViews aufgerufen + AddRazorPages();

            #region IOC Container und Ausgabe an View -Y MyFirstController
            services.AddSingleton<ICar, MockCar>();
            //services.AddScoped<ICar, Car>();
            //services.AddScoped<ICar, MockCar>();
            //services.AddTransient<ICar, MockCar>();
            #endregion

            //Mapping der Konfigurations zur Model-Klasse
            services.Configure<SampleWebSettings>(Configuration);


            services.AddLiveReload();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseLiveReload(); //Ist ein Feature für die Entwickler
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection(); //Https und Umleitungen von A nach B
            app.UseStaticFiles(); // Zugriff auf statische Dateien 

            app.UseRouting(); // Pattern des MVC Aufbaus 

            app.UseAuthorization(); 


            //MVC Middleware 
            app.UseEndpoints(endpoints =>
            {
                //https://localhost:5001/[Preffix_Controllerklasse]/[Action-Methode]/[optionale_ID]
                //https://localhost:5001/Home/Index -> Startseite 
                //https://localhost:5001/Home -> Startseite 
                //https://localhost:5001/ -> Startseite 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //Default Route und diese zeigt den Aufbau einer URL 
            });
        }
    }
}
