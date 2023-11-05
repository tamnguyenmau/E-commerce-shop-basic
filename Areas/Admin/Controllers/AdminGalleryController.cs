using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace EShopSilicon.Areas.Admin.Controllers
{
    public class AdminGalleryController : Controller
    {
        public INotyfService _notyfService { get; }
        private IWebHostEnvironment Environment;
        public AdminGalleryController(IWebHostEnvironment _environment, INotyfService notyfService)
        {
            Environment = _environment;
            _notyfService = notyfService;
        }

        private string SaveImage(string base64)
        {
            base64 = base64.Replace("data:image/jpeg;base64,", string.Empty);
            base64 = base64.Replace("data:image/jpg;base64,", string.Empty);
            base64 = base64.Replace("data:image/gif;base64,", string.Empty);
            base64 = base64.Replace("data:image/png;base64,", string.Empty);

            string rootFolder = this.Environment.WebRootPath;
            string fileName = Guid.NewGuid() + ".jpg";
            byte[] bytes = Convert.FromBase64String(base64);
            string folderSave = $"/FileUpload/Gallery/{fileName}";
            string folderDownload = $"{rootFolder}/{folderSave}".Replace("/", "\\");
            System.IO.File.WriteAllBytes(folderDownload, bytes);
            return folderSave;
        }
        private bool ValidateForm(Gallery item)
        {
            if (item.Avatar == null)
            {
                ViewBag.MessageText = "Vui lòng chọn 1 hình ảnh";
                ViewBag.MessageClass = "alert-warning";
                return false;
            }
            else
            {
                return true;
            }
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/galleries", Name = "AdminGalleries")]
        public IActionResult Index()
        {
            DBContext db = new DBContext();
            var data = db.Galleries
                         .Where(x => x.Status == true)
                         .ToList();
            return View(data);
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/galleries-detail/{id?}", Name = "AdminGalleriesDetail")]
        public IActionResult Detail(int? id)
        {
            DBContext db = new DBContext();
            var category = db.Galleries
                             .OrderBy(x => x.Position)
                             .ToList();
            ViewBag.GalleryCategory = category;

            var item = db.Galleries.Find(id);
            if (item == null)
            {
                item = new Gallery();
                item.Avatar = "/Content/images/no-image.png";
                return View(item);
            }
            else
                return View(item);
        }

        [Area("Admin")]
        [HttpPost]
        [Route("admin/galleries-detail/{id?}", Name = "AdminGalleriesDetail")]
        public IActionResult Detail(int? id, Gallery item)
        {
            DBContext db = new DBContext();

            if (!ValidateForm(item))
            {
                var category = db.Galleries.OrderBy(x => x.Position).ToList();
                ViewBag.Galleries = category;
                return View(item);
            }

            if (id > 0)
            {
                item.GalleryId = id.Value;
                var existItem = db.Galleries.Find(id);
                if (existItem == null)
                    return View();

                existItem.GalleryId = item.GalleryId;

                existItem.Title = item.Title;
                

                if (item.Avatar != null && item.Avatar.StartsWith("data:image"))
                {
                    existItem.Avatar = SaveImage(item.Avatar);
                }
            }
            else
            {
                item.CreateTime = DateTime.Now;
                item.Status = true;
                item.CreateBy = HttpContext.Session.GetString("Username") ?? null;
                if (item.Avatar != null && item.Avatar.StartsWith("data:image"))
                {
                    item.Avatar = SaveImage(item.Avatar);
                }
                db.Entry(item).State = EntityState.Added;
            }
            _notyfService.Success("Tạo mới thành công");
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/galleries-delete/{id}", Name = "AdminGalleriesDelete")]
        public IActionResult Delete(int id)
        {
            DBContext db = new DBContext();
            var item = db.Galleries.Find(id);

            if (item != null)
            {
                db.Galleries.Remove(item);
                db.SaveChanges();
            }
            _notyfService.Success("Xoá thành công");
            return RedirectToAction(nameof(Index));
        }
    }
}
