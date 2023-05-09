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
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Dal());
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetAllTWithMessageByWriter(user.Id).Where(x => x.MessageStatus == true).ToList(); 

            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values = mm.GetTById(id);
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
        public async Task<IActionResult> AddMessageAsync()
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
        public async Task<IActionResult> AddMessageAsync(Message2 message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.SenderID = user.Id;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
            mm.TAdd(message);
            return RedirectToAction("Sendbox", "Message");
        }
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetAllTWithMessageByWriterSendBox(user.Id).Where(x => x.MessageStatus == true).ToList(); 
            return View(values);
        }
        public IActionResult MessageDelete(int id)
        {
            var message = mm.GetTById(id);
            mm.TUpdate(message);
            return RedirectToAction("Inbox", "Message");
        }

    }
}
