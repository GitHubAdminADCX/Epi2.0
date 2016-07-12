﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebClient.Models.Pages;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class HomeController : PageController<StandardPageType>
    {
        public ActionResult Index(StandardPageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = PageViewModel.Create(currentPage);         

            return View(model);
        }
    }
}