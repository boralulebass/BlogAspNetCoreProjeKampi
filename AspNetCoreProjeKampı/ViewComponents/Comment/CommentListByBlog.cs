using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Views.Shared.Components.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetAllCommentsByID(id);
            if (values == null || values.Count == 0)
            {
                ViewBag.Warning = "    (Henüz bir yorum yok, ilk yorumu sen yap!)";
                return View(values);
            }
            else
            {
                ViewBag.Warning = "";
                return View(values);
            }
        }
    }
}
