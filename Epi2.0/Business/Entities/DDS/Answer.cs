using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Business.Entities.DDS
{

    ///FRM012
    /// Author:Amol Pawar
    ///Purpose of the Class : Forum for user where any user can post question and someone can answer to that question.
    ///Dependent entities : AnswerViewModel,ForumController and its view.
    ///How to use: 1. Create One PageType with property where user can post question.
    ///            2. Create simple MVC controller and view which inherites this Pagetype. 
    ///            3. Create DDS Table as in DDSAnswer.txt file. Add class for the table(Create Answer class and inherite it from IDynamicData.)
    ///            4. Create Service to implement logic add Answer, get All Answer,Delete Answers.
    [EPiServerDataTable(TableName = "tblBigTableAnswer")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "AnswerStore")]
    public class Answer : IDynamicData
    {
        public Identity Id { get; set; }       
        public string AnswerID { get; set; }
        public int PageId { get; set; }
        public string AnswerText { get; set; }
        public string UserName { get; set; }

        public DateTime Date { get; set; }
        public bool IsAnswerDeleted { get; set; }
    }
}