using Microsoft.AspNetCore.Mvc;
using UsingUrlRouting.Models;

namespace UsingUrlRouting.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });

        public ViewResult CustomVariable([FromRoute] string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable),
            };
            r.Data["Id"] = id?? "<NULL>";
            r.Data["catchall"] = RouteData.Values["catchall"]; ;
            return View("Result", r);
        }
    }
}
