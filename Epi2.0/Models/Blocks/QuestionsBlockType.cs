using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebClient.Models.Blocks
{
    [ContentType(DisplayName = "QuestionsBlockType", GUID = "c7b23ea9-3a58-45bd-bc6a-30610f4a9f5e", Description = "")]
    public class QuestionsBlockType : BlockData
    {
        //QuestionsBlockType 1
        [CultureSpecific]
        [Display(
            Name = "Question-1",
            Description = "Question text",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Questions1 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 -1",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 2)]
        public virtual string AnswerOption11 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image -1",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 3)]
        public virtual ContentReference AnswerOption1Image1 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2 -1",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 4)]
        public virtual string AnswerOption21 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Answer option 3 -1",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 5)]
        public virtual string AnswerOption31 { get; set; }

       
        [CultureSpecific]
        [Display(
                  Name = "Answer option 4 -1",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 7)]
        public virtual string AnswerOption41 { get; set; }

           [CultureSpecific]
        [Display(
                   Name = "Correct Answer -1",
                   Description = "Correct Answer",
                   GroupName = SystemTabNames.Content,
                   Order = 10)]
        public virtual string CorrectAnswer1 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Correct Answer Description -1",
                  Description = "Put correct answer description here",
                  GroupName = SystemTabNames.Content,
                  Order = 11)]
        public virtual string CorrectAnswerDescription1 { get; set; }

        //QuestionsBlockType 2
        [CultureSpecific]
        [Display(
       Name = "Question2 -2",
       Description = "Question text",
       GroupName = SystemTabNames.Content,
       Order = 1)]
        public virtual string Questions2 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 -2",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 13)]
        public virtual string AnswerOption12 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image -2",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 14)]
        public virtual ContentReference AnswerOption1Image2 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2 -2",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 15)]
        public virtual string AnswerOption22 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 3 -2",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 16)]
        public virtual string AnswerOption32 { get; set; }

              [CultureSpecific]
        [Display(
                  Name = "Answer option 4 -2",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 17)]
        public virtual string AnswerOption42 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Correct Answer -2",
                   Description = "Correct Answer",
                   GroupName = SystemTabNames.Content,
                   Order = 18)]
        public virtual string CorrectAnswer2 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Correct Answer Description -2",
                  Description = "Put correct answer description here",
                  GroupName = SystemTabNames.Content,
                  Order = 19)]
        public virtual string CorrectAnswerDescription2 { get; set; }

        //QuestionsBlockType 3
        [CultureSpecific]
        [Display(
       Name = "Question -3",
       Description = "Question text",
       GroupName = SystemTabNames.Content,
       Order = 20)]
        public virtual string Questions3 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 -3",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 21)]
        public virtual string AnswerOption13 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image -3",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 22)]
        public virtual ContentReference AnswerOption1Image3 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2 -3",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 23)]
        public virtual string AnswerOption23 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 3 -3",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 24)]
        public virtual string AnswerOption33 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 4 -3",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 25)]
        public virtual string AnswerOption43 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Correct Answer -3",
                   Description = "Correct Answer",
                   GroupName = SystemTabNames.Content,
                   Order = 26)]
        public virtual string CorrectAnswer3 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Correct Answer Description -3",
                  Description = "Put correct answer description here",
                  GroupName = SystemTabNames.Content,
                  Order = 27)]
        public virtual string CorrectAnswerDescription3 { get; set; }

        //QuestionsBlockType 4
        [CultureSpecific]
        [Display(
       Name = "Question -4",
       Description = "Question text",
       GroupName = SystemTabNames.Content,
       Order = 28)]
        public virtual string Questions4 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 -4",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 29)]
        public virtual string AnswerOption14 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image -4",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 30)]
        public virtual ContentReference AnswerOption1Image4 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2 -4",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 31)]
        public virtual string AnswerOption24 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 3 -4",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 32)]
        public virtual string AnswerOption34 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 4 -4",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 33)]
        public virtual string AnswerOption44 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Correct Answer -4",
                   Description = "Correct Answer",
                   GroupName = SystemTabNames.Content,
                   Order = 34)]
        public virtual string CorrectAnswer4 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Correct Answer Description -4",
                  Description = "Put correct answer description here",
                  GroupName = SystemTabNames.Content,
                  Order = 34)]
        public virtual string CorrectAnswerDescription4 { get; set; }

        //QuestionsBlockType 5
        [CultureSpecific]
        [Display(
       Name = "Question -5",
       Description = "Question text",
       GroupName = SystemTabNames.Content,
       Order = 35)]
        public virtual string Questions5 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 -5",
                   Description = "Answer option 1 text",
                   GroupName = SystemTabNames.Content,
                   Order = 35)]
        public virtual string AnswerOption15 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Answer option 1 Image -5",
                   Description = "Answer option 1 Image",
                   GroupName = SystemTabNames.Content,
                   Order = 36)]
        public virtual ContentReference AnswerOption1Image5 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 2 -5",
                  Description = "Answer option 2 text",
                  GroupName = SystemTabNames.Content,
                  Order = 37)]
        public virtual string AnswerOption25 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 3 -5",
                  Description = "Answer option 3 text",
                  GroupName = SystemTabNames.Content,
                  Order = 38)]
        public virtual string AnswerOption35 { get; set; }

        [CultureSpecific]
        [Display(
                  Name = "Answer option 4 -5",
                  Description = "Answer option 4 text",
                  GroupName = SystemTabNames.Content,
                  Order = 39)]
        public virtual string AnswerOption45 { get; set; }

        [CultureSpecific]
        [Display(
                   Name = "Correct Answer -5",
                   Description = "Correct Answer",
                   GroupName = SystemTabNames.Content,
                   Order = 40)]
        public virtual string CorrectAnswer5 { get; set; }


        [CultureSpecific]
        [Display(
                  Name = "Correct Answer Description -5",
                  Description = "Put correct answer description here",
                  GroupName = SystemTabNames.Content,
                  Order = 41)]
        public virtual string CorrectAnswerDescription5 { get; set; }
        //public virtual string BlockId
        //{
        //    get
        //    {
        //        return (this as IContent).ContentLink.ID.ToString();
        //    }
        //    set
        //    {
        //    }
        //}
    }
}