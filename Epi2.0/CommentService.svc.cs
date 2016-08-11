using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WebClient.Business.Entities.DDS;

namespace WebClient
{
    [ServiceContract(Namespace = "CommentService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommentService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public string DoWork()
        {
            // Add your operation implementation here
            return "Heloo";
        }

      

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        public Comment Addcomment(int pageId, string commentText, string urlstring, string commentId)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            string CommentGuid = Guid.NewGuid().ToString();
            var comment = new Comment()
            {
                CommentId = CommentGuid,
                CommentText = commentText,
                Date = DateTime.Now,
                UserName = "AP",
                PageId = pageId,
                IsCommentDeleted = false,
                ParentCommentId = commentId == "" ? "" : commentId

            };

            commentStore.Save(comment);

            { }

            var er = commentStore.Items<Comment>();

            var query = from comments in er
                        where comments.CommentId == CommentGuid                        
                        select comments;

            var list = query.ToList<Comment>();

            return list[0];
        }


       
        [OperationContract]
        [WebInvoke(Method = "GET")]
        public List<Comment> GetAllChildComments(string ParentCommentId)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            var er = commentStore.Items<Comment>();
            var query = from comments in er
                        where comments.ParentCommentId == ParentCommentId
                        orderby comments.Date ascending
                        select comments;
            var list = query.ToList<Comment>();

            return list;
        }

    }
    }
