using EPiServer.PlugIn;
using EPiServer.Shell.WebForms;

namespace WebClient.Models.Pages
{
    [GuiPlugIn(
    DisplayName = "Admin Tool For Location",
    RequiredAccess = EPiServer.Security.AccessLevel.Administer,
    Area = PlugInArea.AdminMenu,
    UrlFromModuleFolder = "/AdminToolLocation")]
    public class AdminToolLocation : WebFormsBase
    {
        
    }
}