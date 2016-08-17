using EPiServer.Core;
using EPiServer.Web.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Blocks;

namespace WebClient.Models.ViewModels
{
    public class CommentViewModel
    {
        public string pageURl { get; set; }
        public List<Comment> Comments { get; set; }
        public PageData Page { get; set; }
        public int pageId { get; set; }

        
        public CommentBlock commentblockproperties { get; set; }

    }
}