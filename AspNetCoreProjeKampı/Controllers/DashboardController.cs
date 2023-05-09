using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Context c = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 =c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=>x.Writer.WriterMail==user.Email).Count().ToString();
            ViewBag.v3 =c.Categories.Count().ToString();
            return View();
        }
    }
}
