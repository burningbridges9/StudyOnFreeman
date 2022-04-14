using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddMvc();
services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("test"));
services.AddScoped<IProductRepository, EFProductRepository>();

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: null, pattern: "{category}/Page{productPage:int}", defaults: new { controller = "Product", action = "List" });
    endpoints.MapControllerRoute(name: null, pattern: "Page{productPage:int}", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: null, pattern: "{category}", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: null, pattern: "", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=List}/{id?}");
});
SeedData.EnsurePopulated(app);
app.Run();
