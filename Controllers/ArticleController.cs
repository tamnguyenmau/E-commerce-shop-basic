using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EShopSilicon.Controllers
{
    public class ArticleController : Controller
    {
        [Route("/article", Name = "ArticleList")]
        public IActionResult Index(int? page)
        {
            DBContext dbContext = new DBContext();
            var data = dbContext.Articles
                                .Where(x => x.Status == true)
                                .OrderBy(x => x.Position)
                                .ToList();
            return View(data);
        }
        [Route("/article-view/{id}", Name = "ArticleDetail")]
        public IActionResult Detail(int id)
        {
            DBContext dbContext = new DBContext();
            var data = dbContext.Articles
                                .Where(x => x.Status == true && x.ArticleId == id)
                                .OrderBy(x => x.Position)
                                .FirstOrDefault();
            return View(data);
        }
    }
}