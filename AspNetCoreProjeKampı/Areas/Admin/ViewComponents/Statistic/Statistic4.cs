using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
