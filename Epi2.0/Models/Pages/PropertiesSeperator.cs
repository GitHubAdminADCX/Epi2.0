using WebClient.HelperClass;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models.Pages
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


    [ContentType(DisplayName = "PropertiesSeperator", GUID = "003FFE41-145E-46D2-BB50-3910879B1799", Description = "This Is Property Seperator page")]
    public class PropertiesSeperator : PageData
    {
        [Display(Order = 1, Description = "TestProperty to display Horizontal line", Name = "TestProperty")]
        [BackingType(typeof(DividerProperty))]
        [UIHint("Divider")]
        public virtual string TestProperty { get; set; }

        [Display(Order = 2, Description = "Test Property", Name = "TestProperty")]
        public virtual string ABC { get; set; }
    }
}