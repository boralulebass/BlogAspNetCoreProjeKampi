using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreProjeKampı.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(Contact contact)
		{
            contact.ContactStatus = true;
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAdd(contact);
			return RedirectToAction("Index","Blog");
		}



	}
}
