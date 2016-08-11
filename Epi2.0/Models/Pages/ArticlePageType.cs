using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using WebClient.Models.Blocks;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "ArticlePageType", GUID = "99cdc557-7318-45ba-b264-a025cade2f29", Description = "")]
    public class ArticlePageType : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
                  Name = "Links",
                  GroupName = SystemTabNames.Content,
                  Order = 2)]
        [Editable(true)]
        public virtual LinkPropertyBlock LinksBlock { get; set; }

    }
}