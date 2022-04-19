using Microsoft.AspNetCore.Routing.Constraints;
using UsingUrlRouting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddMvc();


var app = builder.Build();

app.UseRouting();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseEndpoints(endpoints =>
{
    /*������ ������ � ���������*/
    endpoints.MapControllerRoute(name: "area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


    /* ������ ��� ��������� ��������� ������
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "outbound", pattern: "outbound/{controller=Home}/{action=Index}");
    */

    // ������������� �� ������ ����������

    /* ����������� �����������
    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" }, constraints: new { id = new WeekDayConstraint() }); // id - ������ int, ������������
    */

    /* ����������� ���������
    //endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id:int?}"); // id - ������ int, ������������
    // ���
    //endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}", 
    //    defaults: new {controller = "Home", action = "Index"}, constraints: new {id = new IntRouteConstraint()}); // id - ������ int, ������������
    // ���
    //endpoints.MapControllerRoute(name: "default", "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}"); // ����������� ������� �������� �� ������ ��������
    // ���
    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}",
     defaults: new { controller = "Home", action = "Index" },
     constraints: new { id = new CompositeRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(), new MinLengthRouteConstraint(6) }) });
    */

    /* ���������� ���������� ���������
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
    */

    /*
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    */

    /*
    endpoints.MapControllerRoute(name: "ShopSchema2", pattern: "Shop/OldAction", defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllerRoute(name: "ShopSchema1", pattern: "Shop/{action}", defaults: new { controller = "Home" });
    endpoints.MapControllerRoute(name: "", pattern: "X{controller}/{action}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");
    endpoints.MapControllerRoute(name: "", pattern: "Public/{controller=Home}/{action=Index}");
    */
});
app.Run();
