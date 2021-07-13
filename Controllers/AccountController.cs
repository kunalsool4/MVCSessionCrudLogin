using LoginCrud.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LoginCrud.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {

            if (user.Email.Equals("kunal@gmail.com") && user.Password.Equals("123"))
            {
                HttpContext.Session.SetString("username", JsonConvert.SerializeObject("kunal"));
                return RedirectToAction("index", "Emp");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Login");
            }

        }

        public async Task<IActionResult> Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                if (cookie == ".AspNetCore.Session")
                    Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
