using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProjeKampı.Controllers
{
    [AllowAnonymous]
    public class NotifiationController : Controller
    {
        
        NotificationManager nm = new NotificationManager(new EFNotificationDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotifications()
        {
            var values =nm.GetAllTs();
            return View(values);
        }
    }
}
