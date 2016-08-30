using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Epi2._0.Models.Custom.Attributes;
using EPiServer;
using WebClient.Models.Blocks;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "StandardPageType", GUID = "566c8a3a-be39-467f-a8c6-5230701b83d9", Description = "This is a standard page type model")]
    public class StandardPageType : PageData
    {
        [Display(Name = "Content Area",
    Description = "A block that lists latest books.",
    GroupName = SystemTabNames.Content,
    Order = 3)]
        public virtual ContentArea LatestBooks { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [ValidationProperty]
        public virtual XhtmlString MainBody { get; set; }

        //FRM019:custom property editor 
        [CultureSpecific]
        [Display(
          Name = "Autocomplete keywords (Please use ',' to seperate two words)",
          Description = "Autocomplete keywords",
          GroupName = SystemTabNames.Settings,
          Order = 1)]
        [UIHint(UIHint.Textarea)]
        public virtual string Autocompletekeywords { get; set; }

    }
}