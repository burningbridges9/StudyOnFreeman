using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult List(string category, int productPage = 1) => 
            View(new ProductsListViewModel
            {
                Products = productRepository.Products
                                  .Where(p => category == null || p.Category == category)
                                  .OrderBy(p => p.ProductId)
                                  .Skip((productPage - 1) * PageSize)
                                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = productRepository.Products.Count(p=> category == null || p.Category == category)
                },
                CurrentСategory = category
            });
    }
}
