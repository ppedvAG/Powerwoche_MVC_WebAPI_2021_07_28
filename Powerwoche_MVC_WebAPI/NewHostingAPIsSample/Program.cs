
//#region Default-Implementierung
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Hosting;
//using System;

//var builder = WebApplication.CreateBuilder(args);
//await using var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.MapGet("/", (Func<string>)(() => "Hello World!"));

//await app.RunAsync();

//#endregion


//#region Sample 1 - Simple WebAPI

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using NewHostingAPIsSample.Data;
using System;

//Configuer Service
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
});
builder.Services.AddDbContext<PeopleDBContext>(options =>
{
    options.UseInMemoryDatabase("PeopleDB");
});

var app = builder.Build();

//Configure
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//Initialiesierung 
SeedDatabase(app);
app.Run();





static void SeedDatabase(IHost host)
{
    var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PeopleDBContext>();

        if (context.Database.EnsureCreated())
        {
            try
            {
                SeedData.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "A database seeding error occurred.");
            }
        }
    }
}
