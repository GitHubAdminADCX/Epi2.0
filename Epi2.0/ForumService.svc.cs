using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WebClient.Business.Entities.DDS;

namespace WebClient
{
    ///FRM012
    /// Author:Amol Pawar
    ///Purpose of the Class : Forum for user where any user can post question and someone can answer to that question.
    ///Dependent entities : AnswerViewModel,ForumController and its view.
    ///How to use: 1. Create One PageType with property where user can post question.
    ///            2. Create simple MVC controller and view which inherites this Pagetype. 
    ///            3. Create DDS Table as in DDSAnswer.txt file. Add class for the table(Create Answer class and inherite it from IDynamicData.)
    ///            4. Create Service to implement logic add Answer, get All Answer,Delete Answers.
    [ServiceContract(Namespace = "ForumService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ForumService
    {
        [OperationContract]
        [WebGet]
        public string DoWork()
        {
            // Add your operation implementation here
            return "Hello";
        }

        // Add more operations here and mark them with [OperationContract]


        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        public Answer PostAnswer(int pageId, string answer)
        {
            var AnswerStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Answer));
            string AnswerGuid = Guid.NewGuid().ToString();
            var Answer = new Answer()
            {
                AnswerID = AnswerGuid,
                AnswerText = answer,
                Date = DateTime.Now,
                UserName = "AP",
                PageId = pageId,
                IsAnswerDeleted = false,
            };

            AnswerStore.Save(Answer);


            var er = AnswerStore.Items<Answer>();

            var query = from Answers in er
                        where Answers.AnswerID == AnswerGuid
                        select Answers;

            var list = query.ToList<Answer>();

            return list[0];
                     
        }

        [OperationContract]
        [WebInvoke(Method = "GET")]
        public bool DeleteAnswer(string ansID)
        {
            try
            {
                using (var AnswerStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Answer)))
                {
                    var Answer = AnswerStore.Items<Answer>()
                        .Where(x => x.AnswerID == ansID)
                        .FirstOrDefault();
                    if (Answer != null)
                    {
                        Answer.IsAnswerDeleted = true;
                        AnswerStore.Save(Answer);
                        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
          
            
        }



        [OperationContract]
        [WebInvoke(Method = "GET")]
        public List<Answer> loadAnswers(int pageId)
        {
            var AnswerStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Answer));
            var er = AnswerStore.Items<Answer>();
            var query = from Answers in er
                        where Answers.PageId == pageId && Answers.IsAnswerDeleted == false
                        orderby Answers.Date ascending
                        select Answers;
            var list = query.ToList<Answer>();

            return list;
        }


    }
}
