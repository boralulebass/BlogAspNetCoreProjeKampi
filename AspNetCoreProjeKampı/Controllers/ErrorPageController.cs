using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
    public class ErrorPageController : Controller
	{
		[AllowAnonymous]

		public IActionResult Error1(int code)
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
