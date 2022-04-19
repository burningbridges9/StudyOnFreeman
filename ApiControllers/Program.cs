using ApiControllers.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddMvc();
services.AddSingleton<IRepository, MemoryRepository>();


var app = builder.Build();

app.UseRouting();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
