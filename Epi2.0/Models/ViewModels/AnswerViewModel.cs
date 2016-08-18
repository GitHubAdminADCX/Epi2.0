using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.Models.Pages;

namespace WebClient.Models.ViewModels
{
    ///FRM012
    /// Author:Amol Pawar
    ///Purpose of the Class : Forum for user where any user can post question and someone can answer to that question.
    ///Dependent entities : AnswerViewModel,ForumController and its view.
    ///How to use: 1. Create One PageType with property where user can post question.
    ///            2. Create simple MVC controller and view which inherites this Pagetype. 
    ///            3. Create DDS Table as in DDSAnswer.txt file. Add class for the table(Create Answer class and inherite it from IDynamicData.)
    ///            4. Create Service to implement logic add Answer, get All Answer,Delete Answers.
    public class AnswerViewModel
    {
        public int pageId { get; set; }
        public Forum ForumProperties { get; set; }
    }
}