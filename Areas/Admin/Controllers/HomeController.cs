using Microsoft.AspNetCore.Mvc;

namespace EShopSilicon.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Route("admin", Name = "AdminHome")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
