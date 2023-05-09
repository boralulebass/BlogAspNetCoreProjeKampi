using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        private readonly UserManager<AppUser> _userManager;

        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetAllWithCategoryWriter();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = bm.GetListLinqBlog(id);
            return View(values);
        }
        public async Task<IActionResult> BlogListByWriterAsync()
        {
            //WriterManager wm = new WriterManager(new EFWriterDal());
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = bm.GetListIncludedByWriter(userId.Id);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> categories = (from x in cm.GetAllTs()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            BlogValidator wv = new BlogValidator();
            ValidationResult validationResult = new ValidationResult();
            validationResult = wv.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                var userId = await _userManager.FindByNameAsync(User.Identity.Name);
                blog.AppUserID = userId.Id;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult BlogDelete(int id)
        {
            var values = bm.GetTById(id);
            bm.TDelete(values);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            CategoryManager cm = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> categories = (from x in cm.GetAllTs()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            var blogvalue = bm.GetTById(id);
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
