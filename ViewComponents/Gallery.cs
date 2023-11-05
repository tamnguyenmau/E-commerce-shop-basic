using Microsoft.AspNetCore.Mvc;
using EShopSilicon.Models;

namespace EShopSilicon.ViewComponents
{
    public class Gallery : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            DBContext dBContext = new DBContext();
            var data = dBContext.Galleries.Where(x => x.Status == true).OrderBy(x => x.Position).ToList();
            return View(data);
        }
    }
}
