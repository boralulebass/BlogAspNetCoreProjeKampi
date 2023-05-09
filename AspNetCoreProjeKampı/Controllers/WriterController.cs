using AspNetCoreProjeKampı.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AspNetCoreProjeKampı.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public WriterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult WriterLayout()
        {
            return View();
        }
        public PartialViewResult PartialWriterNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialWriterFooter()
        {
            return PartialView();
        }
        [Authorize]
        public IActionResult WriterTest()
        {
            var usermail = User.Identity.Name;
            var values = wm.GetAllTs().Where(x => x.WriterMail == usermail).Select(x => x.WriterName).FirstOrDefault();
            ViewBag.v = values;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var writerValues = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel viewModel = new UserEditViewModel()
            {
                aboutSection = writerValues.WriterAbout,
                phoneNumber = writerValues.PhoneNumber,
                imageUrl = writerValues.ImageUrl,
                mail = writerValues.Email,
                nameSurname = writerValues.NameSurname
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = p.nameSurname;
            values.Email = p.mail;
            values.ImageUrl = p.imageUrl;
            values.WriterAbout = p.aboutSection;
            values.PhoneNumber = p.phoneNumber;
            if (!p.ChangePassword)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            }
            await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterStatus = p.WriterStatus;
            w.WriterAbout = p.WriterAbout;
            w.WriterPassword = p.WriterPassword;
            wm.TAdd(w);
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
