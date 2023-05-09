using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Message2Manager mm = new Message2Manager(new EFMessage2Dal());

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetAllTWithMessageByWriter(user.Id).Where(x => x.MessageStatus == true).ToList();
            ViewBag.count = values.Count;
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values = mm.GetTById(id);
            ViewBag.Subject = values.Subject;
            ViewBag.Text = values.MessageText;
            ViewBag.Date = values.MessageDate;
            return View(values);
        }
        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
        [HttpGet]
        public async Task<IActionResult> NewMessage()
        {
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.RecieverUser = recieverUsers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewMessage(Message2 message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.SenderID = user.Id;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
            mm.TAdd(message);
            return RedirectToAction("Sendbox", "AdminMessage");
        }
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetAllTWithMessageByWriterSendBox(user.Id).Where(x => x.MessageStatus == true).ToList();
            ViewBag.count = values.Count;
            return View(values);
        }
        public IActionResult MessageDelete(int id)
        {
            var message = mm.GetTById(id);
            mm.TUpdate(message);
            return RedirectToAction("Inbox", "AdminMessage");
        }
    }
}
