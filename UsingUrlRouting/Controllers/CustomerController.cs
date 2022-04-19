using Microsoft.AspNetCore.Mvc;
using UsingUrlRouting.Models;

namespace UsingUrlRouting.Controllers
{
    [Route("app/[controller]/actions/[action]/{id?}")]
    public class CustomerController : Controller
    {
        // роутинг на основе аттрибутов
        // [Route("myroute")]
        // [Route("[controller]/MyAction")]
        public ViewResult Index() => View("Result",
        new Result
        {
            Controller = nameof(CustomerController),
            Action = nameof(Index)
        });

        public ViewResult List(string id)
        {
            var r = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };

            r.Data["id"] = id ?? "< no value >";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }
    }
}
