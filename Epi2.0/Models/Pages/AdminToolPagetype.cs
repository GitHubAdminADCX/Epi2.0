using EPiServer.PlugIn;
using EPiServer.Shell.WebForms;
using EPiServer.UI;

namespace WebClient.Models.Pages
{
    ///Author:Amol Pawar
    ///Purpose of the Class :A tool available in the admin section of EPiserver the business logic will be put in as per the requirement.
    ///Dependent entities : MyAdminPluginController and its View, RegisterRoutes in Global.ascx,<episerver.shell> section of Web.config 
    ///How to use: 1.Create a pagetype as below, Create Controller and respective view.
    ///            2. Implement a logic for AdminPlugIn.
    ///            3. See the RegisterRoutes in Global.ascx(In Epi 7.5 and above we should overrideR method RegisterRoutes in Gloabla.ascx.
    ///            4. To Determine the URL see the <episerver.shell> section of Web.config.
    ///Points to take care: 
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>

    [GuiPlugIn(
    DisplayName = "My MVC Admin Plugin",    
    RequiredAccess = EPiServer.Security.AccessLevel.Administer,
    Area = PlugInArea.AdminMenu,
    UrlFromModuleFolder = "/MyAdminPlugin")]
    public class AdminToolPagetype : WebFormsBase
    {
       
       
    }
}