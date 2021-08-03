using ASPNETCORE_WEBAPI.Data;
using ASPNETCORE_WEBAPI.Formatters;
using ASPNETCORE_WEBAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiContrib.Core.Formatter.Csv;
using WebApiContrib.Core.Formatter.Protobuf;

namespace ASPNETCORE_WEBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration -> geladene AppSettings.json
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            //services.AddControllers(options =>
            //{
            //    options.FormatterMappings
            //        .SetMediaTypeMappingForFormat("protobuf",
            //          MediaTypeHeaderValue.Parse("application/x-protobuf"));
            //})

            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, new VCardInputFormatter());
                options.OutputFormatters.Insert(0, new VCardOutputFormatter());

                options.InputFormatters.Insert(1, GetJsonPatchInputFormatter());

            }) //WebAPI wird hier eingebunden
             //.AddXmlSerializerFormatters()
             .AddCsvSerializerFormatters() //Hinzufügen eines CSV Serializer 
             .AddNewtonsoftJson();


            //OpenAPI (Konventionen) -> Swagger ist die UI, die auf Konventionen aufbaut. -> Swagger.json
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPNETCORE_WEBAPI", Version = "v1" });
            });

            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseInMemoryDatabase("MovieDB");
            });

            services.AddTransient<IFileService, FileService>();


            services.AddScoped<IVideoStreamService, VideoStreamService>();
            services.AddHttpClient<IVideoStreamService, VideoStreamService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger ist ein Entwickler-Feature -> soll nicht jedem zugänglich sein. 
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASPNETCORE_WEBAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //Endpunkt für die WebAPI - Requests 
            });
        }



        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
