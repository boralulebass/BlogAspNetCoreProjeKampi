using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
	[AllowAnonymous]

	public class AboutController : Controller
	{
		AboutManager am =new AboutManager(new EFAboutDal());
		public IActionResult Index()
		{
			var values = am.GetAllTs();
			return View(values);
		}
		public IActionResult SocialMedia()
		{
			return View();
		}
	}
}
