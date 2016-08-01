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
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;

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


            return View(model);
        }

        /*login get method..
         filtering the URL so that it can properly map to edit mode URL
         created a login block in which the the login and logout link is visible
         if edit mode is logedin then logout text would be displayed otherwise login text would be displayed
         the login and logout text logic is based on cookie created when we login in episerver edit mode.
         the logic is if the cookie is present then display logout text otherwise display login text*/

        public ActionResult LogOut()
        {

            if (Request.Cookies[".EPiServerLogin"] != null)
            {
                var c = new HttpCookie(".EPiServerLogin");
                c.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(c);
            }


            return View("~/Views/Login/Index.cshtml");

        }
    }
}