using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EFNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetAllTs();
            return View(values);
        }
    }
}
