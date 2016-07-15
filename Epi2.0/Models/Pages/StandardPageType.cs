using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Shell.ObjectEditing;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "StandardPageType", GUID = "566c8a3a-be39-467f-a8c6-5230701b83d9", Description = "This is a standard page type model")]
    public class StandardPageType : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        /*
        Author:Amol Mahul
        Purpose of the Class : To showcase the use of ColorPalette on string property
        Dependent entities : N/A
        How to use: use the following mentioned attributes on the property to display a color palette
        Points to take care: Use only when the string value is supposed to store CTML color code
        Highlight Risk : <Highlight risk if any involved>
        Comments:  //EditorConfiguration = "{\"palette\": \"3x4\"}") use this additional attribute to change the paletter layout
        */

        [Display(
        GroupName = SystemTabNames.Content,
        Name = "Text Color",
        Order = 50)]
        [ClientEditor(ClientEditingClass = "dijit/ColorPalette")]
        public virtual string TextColor { get; set; }

    }
}