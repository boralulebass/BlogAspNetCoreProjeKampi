using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AspNetCoreProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var values = commentManager.GetTCommentsIncluded().ToPagedList(page, 20);
            return View(values);
        }

        [HttpPost]
        public IActionResult DeleteComment(int id)
        {

            var value = commentManager.GetTById(id);
            if (value.CommentStatus)
            {
                value.CommentStatus = false;
            }
            else
            {
                value.CommentStatus = true;
            }
            commentManager.TUpdate(value);
            return View();
        }
    }
}
