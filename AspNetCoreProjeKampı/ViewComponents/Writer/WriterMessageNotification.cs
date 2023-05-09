using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.ViewComponents.Writer
{

    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Dal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        private readonly UserManager<AppUser> _userManager;

        public WriterMessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writerId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetAllTWithMessageByWriter(writerId.Id);
            ViewBag.count = mm.GetAllTWithMessageByWriter(writerId.Id).Count();
            return View(values);
        }
    }
}
