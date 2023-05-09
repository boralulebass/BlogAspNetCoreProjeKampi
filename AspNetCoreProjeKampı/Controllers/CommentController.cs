using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreProjeKampı.Controllers
{
	[AllowAnonymous]

	public class CommentController : Controller
	{
		CommentManager cm= new CommentManager(new EFCommentDal());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PartialAddComment(Comment comment) 
		{
			comment.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogID = 4;
			cm.TAdd(comment);
			return RedirectToAction("Index","Blog");
		}
		public PartialViewResult PartialCommentListByBlog(int id)
		{
			var values = cm.GetAllCommentsByID(id);
			return PartialView(values);
		}
	}
}
