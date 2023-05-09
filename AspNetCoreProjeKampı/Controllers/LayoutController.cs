using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
	[AllowAnonymous]

	public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
		public PartialViewResult Partial2()
		{
			return PartialView();
		}
		public PartialViewResult Partial3()
		{
			return PartialView();
		}
	}
}
