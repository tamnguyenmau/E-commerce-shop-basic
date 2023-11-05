using Microsoft.AspNetCore.Mvc;
using EShopSilicon.Models;

namespace EShopSilicon.ViewComponents
{
    public class vcMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            DBContext dBContext = new DBContext();
            var data = dBContext.Menus.Where(x => x.Status == true).OrderBy(x => x.Position).ToList();
            return View(data);
        }
    }
}
