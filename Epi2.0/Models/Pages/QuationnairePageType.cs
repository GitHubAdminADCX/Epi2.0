using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "QuationnairePageType", GUID = "66ffd9b3-819c-4fb3-b2b0-cd2ec9cf1213", Description = "")]
    public class QuationnairePageType : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "This section should contain all the information about the page",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString Description { get; set; }

        [CultureSpecific]
        [Display(
                    Name = "Questions",
                    Description = "Associate blocks of type questions",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
        public virtual ContentArea Questions { get; set; }
    }
}