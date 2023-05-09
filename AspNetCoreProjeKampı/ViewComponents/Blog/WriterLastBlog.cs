using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogDal());
		WriterManager wm = new WriterManager(new EFWriterDal());
		private readonly UserManager<AppUser> _userManager;

        public WriterLastBlog(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public  IViewComponentResult Invoke()
		{
            var values = bm.GeTBlogListByWriter(4);
			return View(values);
		}

	}
}
