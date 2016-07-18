using WebClient.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class PropertiesDividerController : PageController<PropertiesSeperator>
    {
        // GET: PropertiesDivider
        public ActionResult Index(PropertiesSeperator currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View(model);
        }
    }
}