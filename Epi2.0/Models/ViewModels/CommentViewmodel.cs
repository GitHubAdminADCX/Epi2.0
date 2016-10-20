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
    public class CommentViewModel
    {
        public string pageURl { get; set; }
        public List<Comment> Comments { get; set; }
        public PageData Page { get; set; }
        public int pageId { get; set; }

        
        public CommentBlock commentblockproperties { get; set; }

        public string publickey { get; set; }

    }
}