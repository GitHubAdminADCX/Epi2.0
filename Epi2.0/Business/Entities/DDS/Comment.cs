
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Business.Entities.DDS
{
    [EPiServerDataTable(TableName = "tblBigTableComment")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "Episerver")]
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