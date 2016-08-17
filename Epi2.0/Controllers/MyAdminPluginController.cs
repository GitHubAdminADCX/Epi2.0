using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class MyAdminPluginController : Controller
    {
        // GET: MyAdminPlugin
        public ActionResult Index()
        {
            //var startpage = DataFactory.Instance.Get<PageData>(ContentReference.StartPage);

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startpage = contentLoader.Get<PageData>(ContentReference.StartPage);
            var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);
            PageDataCollection pages = new PageDataCollection();
            pages.Add(startpage);
            pages.Add(topLevelPages);


            return View(pages);
        }
    }
}