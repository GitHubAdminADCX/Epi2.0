using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Services.PageModel
{
    [ContentType(DisplayName = "QuationnairePageType", GUID = "66ffd9b3-819c-4fb3-b2b0-cd2ec9cf1213", Description = "")]
    public class QuestionnairePageType : PageData
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
                    Order = 2)]
        public virtual ContentArea Questions { get; set; }

        [CultureSpecific]
        [Display(
                    Name = "Form",
                    Description = "a form object to store the results for this questionnaire",
                    GroupName = SystemTabNames.Content,
                    Order = 3)]
        public virtual ContentArea Form { get; set; }

        [CultureSpecific]
        [ScaffoldColumn(false)]
        [Display(
                  Name = "Hidden ID for the block",
                  Description = "Editor can not see this property",
                  GroupName = SystemTabNames.Content,
                  Order = 4)]
        public virtual string PageId
        {
            get
            {
                return (this as IContent).ContentLink.ID.ToString();
            }
            set
            {
            }
        }
    }
}