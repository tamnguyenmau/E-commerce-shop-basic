using EShopSilicon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace EShopSilicon.Areas.Admin.Controllers
{
    public class AdminArticleController : Controller
    {
        private IWebHostEnvironment Environment;
        public INotyfService _notyfService { get; }
        public AdminArticleController(IWebHostEnvironment _environment, INotyfService notyfService)
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
            string folderSave = $"/FileUpload/Article/{fileName}";
            string folderDownload = $"{rootFolder}/{folderSave}".Replace("/", "\\");
            System.IO.File.WriteAllBytes(folderDownload, bytes);
            return folderSave;
        }

        private bool ValidateForm(Article item)
        {
            if (item.ArticleCategoryId == null || item.ArticleCategoryId <= 0)
            {
                ViewBag.MessageText = "Vui lòng chọn 1 thể loại tin tức";
                ViewBag.MessageClass = "alert-warning";
                return false;
            }
            else if (string.IsNullOrEmpty(item.Title))
            {
                ViewBag.MessageText = "Vui lòng nhập tiêu đề tin tức";
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
        [Route("admin/articles", Name = "AdminArticle")]
        public IActionResult Index()
        {
            DBContext db = new DBContext();
            var data = db.Articles
                         .Include(x => x.ArticleCategory)
                         .OrderByDescending(x => x.CreateTime)
                         .Take(20)
                         .ToList();
            return View(data);
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/articles-detail/{id?}", Name = "AdminArticleDetail")]
        public IActionResult Detail(int? id)
        {
            DBContext db = new DBContext();
            var category = db.ArticleCategories
                             .OrderBy(x => x.Position)
                             .ToList();
            ViewBag.ArticleCategory = category;

            var item = db.Articles.Find(id);
            if (item == null)
            {
                item = new Article();
                item.Avatar = "/Content/images/no-image.png";
                return View(item);
            }
            else
                _notyfService.Success("Tạo mới thành công");
            return View(item);
        }

        [Area("Admin")]
        [HttpPost]
        [Route("admin/articles-detail/{id?}", Name = "AdminArticleDetail")]
        public IActionResult Detail(int? id, Article item)
        {
            DBContext db = new DBContext();

            if (!ValidateForm(item))
            {
                var category = db.ArticleCategories.OrderBy(x => x.Position).ToList();
                ViewBag.ArticleCategory = category;
                return View(item);
            }

            if (id > 0)
            {
                item.ArticleId = id.Value;
                var existItem = db.Articles.Find(id);
                if (existItem == null)
                    return View();

                existItem.ArticleCategoryId = item.ArticleCategoryId;
                existItem.Position = item.Position;
                existItem.Title = item.Title;
                existItem.Decs = item.Decs;
                existItem.Content = item.Content;

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
            db.SaveChanges();
            _notyfService.Success("Tạo mới thành công");
            return RedirectToAction(nameof(Index));
        }

        [Area("Admin")]
        [HttpGet]
        [Route("admin/articles-delete/{id}", Name = "AdminArticleDelete")]
        public IActionResult Delete(int id)
        {
            DBContext db = new DBContext();
            var item = db.Articles.Find(id);

            if (item != null)
            {
                db.Articles.Remove(item);
                _notyfService.Success("Xoá thành công");
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
