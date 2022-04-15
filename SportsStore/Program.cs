using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddMvc();
services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("test"));

services.AddDbContext<AppIdentityDbContext>(options => options.UseInMemoryDatabase("test"));
//services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(config["Data:Sportstoreldentity:Connectionstring"]));
services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();


services.AddScoped<IProductRepository, EFProductRepository>();
services.AddScoped<IOrderRepository, EFOrderRepository>();
services.AddMemoryCache();
services.AddSession();
services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: null, pattern: "{category}/Page{productPage:int}", defaults: new { controller = "Product", action = "List" });
    endpoints.MapControllerRoute(name: null, pattern: "Page{productPage:int}", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: null, pattern: "{category}", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: null, pattern: "", defaults: new { controller = "Product", action = "List", productPage = 1 });
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=List}/{id?}");
});
SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);
app.Run();
