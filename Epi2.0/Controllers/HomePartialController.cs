using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models.Pages;

namespace Epi2._0.Controllers
{
    /*
Page used in Content Area do not have a renderer to perform on page editing, create a renderer to show to preview the page in content area
Author:Priti Jadhav
Purpose of the Class : This controller can be used to render a partial view in the content area on page editing view
How to use:
1. Please create partial controller and related index file of any page type to render it in content area prop.

*/

    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController, Inherited = true)]
    public class HomePartialController : PageController<StandardPageType>
    {
        public ActionResult Index(StandardPageType currentPage)
        {
            return PartialView("/Views/HomePartial/Index.cshtml", currentPage);
        }
    }
}