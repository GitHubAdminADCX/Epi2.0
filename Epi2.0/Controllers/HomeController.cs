using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebClient.Models.Pages;
using WebClient.Models.ViewModels;
using System.Web;

namespace WebClient.Controllers
{
    public class HomeController : PageController<StandardPageType>
    {
        public object DateTime1 { get; private set; }

        public ActionResult Index(StandardPageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);

            if (Request.Cookies["UserLoggedin"] == null)
            {
                return RedirectToAction("index", "Login");
            }

            return View(model);
        }

        public ActionResult LogOut()
        {

            if (Request.Cookies[".EPiServerLogin"] != null)
            {
                var c = new HttpCookie(".EPiServerLogin");
                c.Expires =  DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(c);
            }

            if (Request.Cookies["UserLoggedin"] != null)
            {
                var c = new HttpCookie("UserLoggedin");
                c.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("index", "Login");
        }
    }
}