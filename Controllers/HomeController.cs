using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EShopSilicon.Controllers
{
    public class HomeController : Controller
    {
        [Route("/", Name = "Home")]

        public IActionResult Index()
        {
            return View();
        }

        
    }
}