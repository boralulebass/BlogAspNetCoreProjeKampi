using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetAllWithCategoryWriter().OrderByDescending(x => x.BlogID).Take(10).ToList(); ;
            return View(values);
        }
    }
}
