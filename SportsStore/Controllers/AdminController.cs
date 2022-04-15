using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository repository;

        public AdminController(IProductRepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Products);

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            return View(repository.Products.SingleOrDefault(x => x.ProductId == productId));
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Product p)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = $"{p.Name} has been saved";
                repository.SaveProduct(p);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(p);
        }

        [HttpGet]
        public IActionResult Create() => View(nameof(Edit), new Product());

        [HttpPost]

        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
