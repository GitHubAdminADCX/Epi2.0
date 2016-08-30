using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using WebClient.Models.Blocks;

namespace WebClient.Models.Pages
{
    /// ID :FRM007
    ///Author:Kunal Doshi
    [ContentType(DisplayName = "RssPage", GUID = "b1021b57-2c53-463e-9072-00bd5dfd0b42", Description = "")]
    public class RssPage : PageData
    {
        [Display(Name = "Parent",
         Description = "",
         Order = 1)]
        public virtual PageReference ParentPage { get; set; }

        public virtual LocationBlock Location { get; set; }
    }
}