using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models.Entities.User;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    public class UserController : Controller
    {
        MyContext _context;

        public UserController(MyContext context)
        {
            _context = context;
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("register"), HttpPost,ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {
            if(ModelState.IsValid)
            {
               if(_context.users.Any(e=>e.Email==register.Email))
                {
                    ModelState.AddModelError("Email", "ایمیل تکراری میباشد");
                    return View(register); 
                }
                var user = new User()
                {
                    Email = register.Email,
                    Password = register.Password

                };
                _context.users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("login");
            }
            ModelState.AddModelError("ModelOnly", "لطفا فیلد ها را پر کنید");
            return View(register);
        }

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("/Login"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            
            if(ModelState.IsValid)
            {
                var user = _context.users.SingleOrDefault(e => e.Email == login.Email);
                if(user != null)
                {
                   if(user.Password==login.Password)
                   {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                            new Claim(ClaimTypes.Email, login.Email)
                        };
                        var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var Principal = new ClaimsPrincipal(Identity);

                        var Properties = new AuthenticationProperties()
                        {
                            IsPersistent = login.RememberMe
                        };

                        HttpContext.SignInAsync(Principal, Properties);
                        return RedirectToAction("UserDashboard", "User");
                    }
                   ModelState.AddModelError("Email", "اطلاعات وارد شده صحیح نمیباشد");
                    return View();
                }
                ModelState.AddModelError("Email", "اطلاعات وارد شده صحیح نمیباشد");
                return View();

            }
            ModelState.AddModelError("Email", "لطفا فیلد ها را پر کنید");
            return View();
        } 
        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }
        [Authorize]
        public IActionResult UserDashboard()
        {
                return View();
         
        }
    }
}

