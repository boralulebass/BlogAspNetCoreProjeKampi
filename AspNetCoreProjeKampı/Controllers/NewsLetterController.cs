using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
	[AllowAnonymous]

	public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EFNewsLetterDal());
        
        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            nm.NewsLetterAdd(newsLetter);
            return RedirectToAction("Index","Blog");
        }
    }
}
