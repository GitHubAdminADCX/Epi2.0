using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClient.Models.Pages  
{
    ///FRM012
    /// Author:Amol Pawar
    ///Purpose of the Class : Forum for user where any user can post question and someone can answer to that question.
    ///Dependent entities : AnswerViewModel,ForumController and its view.
    ///How to use: 1. Create One PageType with property where user can post question.
    ///            2. Create simple MVC controller and view which inherites this Pagetype. 
    ///            3. Create DDS Table as in DDSAnswer.txt file. Add class for the table(Create Answer class and inherite it from IDynamicData.)
    ///            4. Create Service to implement logic add Answer, get All Answer,Delete Answers.

    [ContentType(DisplayName = "Forum", GUID = "77A3ECC3-0685-4BA2-8CD2-9CEDB8E35B1B", Description = "This Is Forum page")]
    public class Forum : PageData
    {

        [Display(Order = 1, Description = "Question", Name = "Question")]
        public virtual string Question { get; set; }
    }
}