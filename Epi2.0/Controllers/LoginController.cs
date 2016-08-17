
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;
using EPiServer.Configuration;


namespace Epi2._0.Controllers
{
    public class LoginController : BlockController<LoginBlock>
    {
        //FRM008
        // GET: Login
        /*login get method..
        filtering the URL so that it can properly map to edit mode URL
        created a login block in which the the login and logout link is visible
        if edit mode is logedin then logout text would be displayed otherwise login text would be displayed
        the login and logout text logic is based on cookie created when we login in episerver edit mode.
        the logic is if the cookie is present then display logout text otherwise display login text*/
        public override ActionResult Index(LoginBlock lb)
        {
            string url = HttpContext.Request.Url.AbsolutePath.Replace("Login/index", " ");
            string url1 = url.Remove(0) + Settings.Instance.UIUrl.ToString();
            string url12 = url1.Replace("~", "");
            ViewBag.LoginPage = url12;

            return PartialView("~/Views/Login/LoginBlock.cshtml");
        }



        //[HttpPost]
        //public ActionResult Index(LoginModel lm)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (lm.UserName == "admin" && lm.Password == "admin")
        //            {
        //                var userCookie = new HttpCookie("UserLoggedin");
        //                userCookie.Expires.AddDays(365);
        //                HttpContext.Response.Cookies.Add(userCookie);
        //                return null;
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "invalid username or password");

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        var mess = ex.Message;
        //    }
        //    return PartialView("~/Views/Login/LoginBlock.cshtml");
        //}
    }
}