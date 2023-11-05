using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EShopSilicon.Controllers
{
    public class GalleryController : Controller
    {
        [Route("/gallery", Name = "GalleryList=")]
        public IActionResult Index()
        {
            DBContext dbContext = new DBContext();
            var data = dbContext.Galleries.Where(x => x.Status == true).OrderBy(x => x.Position).ToList();
            return View(data);
        }
    }
}