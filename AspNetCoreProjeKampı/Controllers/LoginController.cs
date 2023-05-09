using AspNetCoreProjeKampı.Models;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreProjeKampı.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password,false,true);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }







        //      [HttpPost]
        //      public async Task< IActionResult> Index(Writer writer)
        //      {
        //          Context c = new Context();
        //	var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && writer.WriterPassword == x.WriterPassword);
        //          if (datavalue != null) 
        //          {
        //              var claims = new List<Claim>
        //              { new Claim(ClaimTypes.Name,writer.WriterMail)};
        //              var useridentity = new ClaimsIdentity(claims, "a");
        //              ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //              await HttpContext.SignInAsync(principal);
        //              return RedirectToAction("Index","Dashboard");   
        //          }
        //          else
        //          {
        //              return View();
        //          }

        //}





        //[HttpPost]
        //public IActionResult Index(Writer writer)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && writer.WriterPassword == x.WriterPassword);
        //    if (datavalue != null) 
        //    {
        //        HttpContext.Session.SetString("username", writer.WriterMail);
        //        return RedirectToAction("Index","Blog");
        //    }
        //    return View();
        //}

    }
}
