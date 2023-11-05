using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace EShopSilicon.Areas.Admin.Controllers
{
    public class AdminProductCategoryController : Controller
    {
        public INotyfService _notyfService { get; }
        private IWebHostEnvironment Environment;
        public AdminProductCategoryController(IWebHostEnvironment _environment, INotyfService notyfService)
        {
            Environment = _environment;
            _notyfService = notyfService;
        }

        private bool ValidateForm(ProductCategory item)
        {
            if (item.Position == null)
            {
                ViewBag.MessageText = "Vui lòng chọn vị trí";
                ViewBag.MessageClass = "alert-warning";
                return false;
            }
            else if (string.IsNullOrEmpty(item.Title))
            {
                ViewBag.MessageText = "Vui lòng nhập tiêu đề ";
                ViewBag.MessageClass = "alert-warning";
                return false;
            }
            else
            {
                return true;
            }
        }
        [Area("Admin")]
        [Route("admin/product-category", Name = "AdminProductCategory")]
        public IActionResult Index()
        {
            DBContext db = new DBContext();
            var data = db.ProductCategories
                         .Where(x => x.Status == true)
                         .OrderBy(x => x.Position)
                         .ToList();
            return View(data);
        }
        [Area("Admin")]
        [HttpGet]
        [Route("admin/product-category-detail/{id?}", Name = "AdminProductCategoryDetail")]
        public IActionResult Detail(int? id)
        {
            DBContext db = new DBContext();
            var category = db.ProductCategories
                             .OrderBy(x => x.Position)
                             .ToList();
            ViewBag.ProductCategory = category;

            var item = db.ProductCategories.Find(id);
            if (item == null)
            {
                item = new ProductCategory();
                return View(item);
            }
            else
                return View(item);
        }

        [Area("Admin")]
        [HttpPost]
        [Route("admin/product-category-detail/{id?}", Name = "AdminProductCategoryDetail")]
        public IActionResult Detail(int? id, ProductCategory item)
        {
            DBContext db = new DBContext();

            if (!ValidateForm(item))
            {
                var category = db.ProductCategories.OrderBy(x => x.Position).ToList();
                ViewBag.ProductCategory = category;
                return View(item);
            }

            if (id > 0)
            {
                item.ProductCategoryId = id.Value;
                var existItem = db.Products.Find(id);
                if (existItem == null)
                    return View();


            }
            else
            {
                item.CreateTime = DateTime.Now;
                item.Status = true;
                item.CreateBy = HttpContext.Session.GetString("Username") ?? null;
                db.Entry(item).State = EntityState.Added;
            }
            _notyfService.Success("Tạo mới thành công");
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/product-category-delete/{id}", Name = "AdminProductCategoryDelete")]
        public IActionResult Delete(int id)
        {
            DBContext db = new DBContext();
            var item = db.ProductCategories.Find(id);

            if (item != null)
            {
                db.ProductCategories.Remove(item);
                db.SaveChanges();
            }
            _notyfService.Success("Xoá thành công");
            return RedirectToAction(nameof(Index));
        }
    }
}
