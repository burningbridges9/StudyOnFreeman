using Microsoft.AspNetCore.Mvc;
using UsingUrlRouting.Areas.Admin.Models;

namespace UsingUrlRouting.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[] 
        { 
            new Person { Name = "Alice", City = "London" }, 
            new Person { Name = "Bob", City = "Paris" }, 
            new Person { Name = "Joe", City = "New York" } 
        };

        public ViewResult Index() => View(data);
    }
}
