﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace WebClient.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string empty)
        {
            // Code for validating the CAPTCHA  
            if (this.IsCaptchaValid("Captcha is valid"))
            {

                return RedirectToAction("ThankYouPage");
            }

            ViewBag.ErrMessage = "captcha is not valid.";
            return View();
        }

        public ActionResult ThankYouPage()
        {
            return View();
        }
    }
}