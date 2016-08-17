using WebClient.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    ///Author:Amol Pawar
    ///Purpose of the Class :A simple horizontal line separating two properties in edit mode of a page
    ///Dependent entities : Helper Class  DividerProperty, PropertyEditorDescriptor. Helper JS,CSS - Folder Name ClientResources. Module.Config . PropertiesDividerController and its view(Optional, Depends on ur requirements)
    ///How to use: 1. Create One PageType As below including two properties which wants to seperate.
    ///            2. Set BackingType as DividerProperty (...[BackingType(typeof(DividerProperty))]....) .
    ///            3. Add helper Class DividerProperty , PropertyEditorDescriptor.
    ///            4. Add JS And CSS as in path ClientResources(See the ClientResources Folder.
    ///            5. Addd module.config and edit as per project solution.
    ///Points to take care: The specification in module.config <dojoModules>
    ///                                                        <add name = "custom" path="Scripts" />
    ///                                                        </dojoModules>
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>



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