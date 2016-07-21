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
    public class ValidationPreviewRendererController : PageController<ValidationPreviewRenderer>
    {
        // GET: ValidationPreviewRenderer
        public ActionResult Index(ValidationPreviewRenderer currentpage)
        {
            var model = PageViewModel.Create(currentpage);
            return View(model);
        }
    }
}