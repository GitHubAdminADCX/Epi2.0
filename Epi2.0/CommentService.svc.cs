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
    ///FRM010
    /// Author:Amol Pawar
    ///Purpose of the Class :Generic Functionality(block) to Comment on any type of page with the use of CommentBlock.
    ///Dependent entities : CommentBlock, Pagetype where block can be render,CommentBlockController,Comment.cs,CommentViewModel.cs,DDSComment,CommentService.svc
    ///How to use: 1. Create blockType, controller for block and its view.
    ///            2. Add contentArea in page where we can render this block.
    ///            3. Create DDS table and its class to map the DDS table(Comment.cs)
    ///            4. Create Service to implement the module's logic(CommentService.svc),Check the end points created in web.config, if require do changes in web.config as needed under <system.serviceModel>

    ///Points to take care: 
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>
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
