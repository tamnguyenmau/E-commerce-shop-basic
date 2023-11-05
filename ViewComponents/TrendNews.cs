using Microsoft.AspNetCore.Mvc;
using EShopSilicon.Models;

namespace EShopSilicon.ViewComponents
{
    public class TrendNews : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            DBContext dBContext = new DBContext();
            var data = dBContext.Articles.Where(x => x.Status == true).OrderBy(x => x.Position).ToList();
            return View(data);
        }
    }
}
