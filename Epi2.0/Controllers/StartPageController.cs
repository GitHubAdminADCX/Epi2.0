using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models.Pages;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class StartPageController : PageController<StartPageType>
    {
        // GET: StartPage
        public ActionResult Index(StartPageType currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View(model);
        }
    }
}