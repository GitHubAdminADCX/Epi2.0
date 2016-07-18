using Epi2._0.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using WebClient.Models.ViewModels;

namespace Epi2._0.Controllers
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