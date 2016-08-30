
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Business.Entities.DDS
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
    [EPiServerDataTable(TableName = "tblBigTableComment")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "CommentStore")]
    public class Comment : IDynamicData
    {
        public Identity Id { get; set; }
        public int PageId { get; set; }
        public string CommentId { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public bool IsCommentDeleted { get; set; }

        public string ParentCommentId { get; set; }



        //public void Save()
        //{
        //    // Create a data store (but only if one doesn't exist, we won't overwrite an existing one)
        //    DynamicDataStore<Comment> store = DynamicDataStore<Comment>.CreateStore(false);
        //    // Save the current comment
        //    store.Save(this);
        //}

    }
}