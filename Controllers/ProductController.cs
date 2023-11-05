using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EShopSilicon.Controllers
{
    public class ProductController : Controller
    {
        [Route("/product", Name = "Product")]
        public IActionResult Index()
        {
            DBContext dbContext = new DBContext();
            var data = dbContext.Products
                                .Where(x => x.Status == true)
                                .OrderBy(x => x.Position)
                                .ToList();
            return View(data);
        }
        [Route("/product-view={id}", Name = "ProductDetail")]
        public IActionResult Detail(int id)
        {
            DBContext dbContext = new DBContext();
            var data = dbContext.Products
                                .Where(x => x.Status == true && x.ProductId == id)
                                .OrderBy(x => x.Position)
                                .FirstOrDefault();
            return View(data);
        }
    }
}