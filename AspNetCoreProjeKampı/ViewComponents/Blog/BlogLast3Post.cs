using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogDal());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetLast3Blogs();
			return View(values);
		}
	}
}
