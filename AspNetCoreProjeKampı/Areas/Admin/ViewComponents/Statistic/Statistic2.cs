using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            //ViewBag.v2 = c.Contacts.Count();
            //ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
