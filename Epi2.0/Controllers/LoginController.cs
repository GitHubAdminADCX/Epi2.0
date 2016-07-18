using Epi2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Views.Blocks;

namespace Epi2._0.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel lm, DefaultBlock1 d)
        {
            if (ModelState.IsValid)
            {
                if (lm.UserName == "admin" && lm.Password == "admin")
                {
                    var userCookie = new HttpCookie("UserLoggedin");
                    userCookie.Expires.AddDays(365);
                    HttpContext.Response.Cookies.Add(userCookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "invalid username or password");

                }
            }
            return View();
        }
    }
}