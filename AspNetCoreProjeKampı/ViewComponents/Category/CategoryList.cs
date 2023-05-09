using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreProjeKampı.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        BlogManager bm = new BlogManager(new EFBlogDal());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetAllTs();
            return View(values);
        }
    }
}
