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
    public class ArticleController : PageController<ArticlePageType>
    {
        // GET: ArticlePage
        public ActionResult Index(ArticlePageType currentblock)
        {
            var model = new ArticleViewModel();
            
            return View(model);
        }
    }
}