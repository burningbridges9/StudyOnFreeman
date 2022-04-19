using Microsoft.AspNetCore.Mvc;
using UsingUrlRouting.Models;

namespace UsingUrlRouting.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index() => View("Result",
        new Result
        {
            Controller = nameof(AdminController),
            Action = nameof(Index)
        });
    }
}
