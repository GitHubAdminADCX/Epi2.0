using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Services.BlockModel
{
    [ContentType(DisplayName = "QuestionsBlockType", GUID = "c7b23ea9-3a58-45bd-bc6a-30610f4a9f5e", Description = "")]
    public class QuestionsBlockType : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Question",
            Description = "Question text",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString Questions { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 2)]
        public virtual string AnswerOption1 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 3)]
        public virtual ContentReference AnswerOption1Image { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 4)]
        public virtual string AnswerOption2 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 2 Image",
                   Description = "Answer option 2 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 5)]
        public virtual ContentReference AnswerOption2Image { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 3",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 5)]
        public virtual string AnswerOption3 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 3 Image",
                   Description = "Answer option 3 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 6)]
        public virtual ContentReference AnswerOption3Image { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 4",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 7)]
        public virtual string AnswerOption4 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 4 Image",
                   Description = "Answer option 4 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 8)]
        public virtual ContentReference AnswerOption4Image { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Correct Answer option",
                  Description = "Put correct answer in numeric order comma seperated",
                  GroupName = SystemTabNames.Content,
                  Order = 8)]
        public virtual string CorrectAnswer { get; set; }

        [CultureSpecific]
        [ScaffoldColumn(false)]
        [Display(
                  Name = "Hidden ID for the block",
                  Description = "Editor can not see this property",
                  GroupName = SystemTabNames.Content,
                  Order = 8)]
        public virtual string BlockId { 
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