using EShopSilicon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EshopDemo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [Area("Admin")]
        [HttpGet]
        [Route("/admin/login", Name = "AdminLogin")]
        public IActionResult Login()
        {
            ViewBag.LoginMessage = "Xin mời đăng nhập tài khoản";
            ViewBag.LoginClass = "alert-info";
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        [Route("/admin/login", Name = "AdminLogin")]
        public IActionResult Login(Account data)
        {
            DBContext context = new DBContext();
            var item = context.Accounts.FirstOrDefault(x => x.Username == data.Username && x.Password == data.Password);

            if (item == null)
            {
                ViewBag.LoginMessage = "Tài khoản không hợp lệ";
                ViewBag.LoginClass = "alert-danger";
                return View();
            }
            else
            {
                ViewBag.LoginMessage = "Đăng nhập thành công";
                ViewBag.LoginClass = "alert-success";
                ModelState.Clear();

                HttpContext.Session.SetString("Username", item.Username);
                HttpContext.Session.SetString("Fullname", item.FullName ?? string.Empty);
                HttpContext.Session.SetString("Avatar", item.Avatar ?? string.Empty);
                HttpContext.Session.SetString("Email", item.Email ?? string.Empty);
                HttpContext.Session.SetString("Mobile", item.Mobile ?? string.Empty);
                HttpContext.Session.SetString("Address", item.Address ?? string.Empty);
                HttpContext.Session.SetString("AccountCategory", item.AccountCategoryId ?? string.Empty);
                return RedirectToRoute("AdminHome");
            }

        }
        [Area("Admin")]
        [HttpPost]
        [Route("admin/logout", Name = "AdminLogout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [Area("Admin")]
        [HttpGet]
        [Route("/admin/profile", Name = "AdminProfile")]
        public IActionResult Profile()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        [Route("/admin/profile", Name = "AdminProfile")]
        public IActionResult Profile(Account data)
        {
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        [Route("/admin/account", Name = "AdminAccount")]
        public IActionResult Index()
        {
            DBContext db = new DBContext();
            var data = db.Accounts
                         .Where(x => x.Status == true)
                         .ToList();
            return View(data);
        }
    }
}
