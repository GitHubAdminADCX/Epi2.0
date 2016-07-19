using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Epi2._0.Models.Custom.Attributes;
using EPiServer;

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
        [ValidationProperty]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Content Area",
          Description = "",
          GroupName = SystemTabNames.Content,
          Order = 25)]
        public virtual ContentArea TestContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Website url",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 91)]
        [ValidationProperty]
        [BackingType(typeof(PropertyUrl))]
        public virtual Url WebSiteUrl { get; set; }



    }
}