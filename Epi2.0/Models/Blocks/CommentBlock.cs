using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClient.Models.Blocks
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

    [ContentType(DisplayName = "CommentBlock", GUID = "AAB9E4DF-654B-4205-8715-912A18C33687", Description = "Generic Comment Block")]
    public class CommentBlock : BlockData
    {
        [Display(Name = "UserName",
        Description = "A block that lists latest books.",
        Order = 1)]
        public virtual string Commentexbox { get; set; }
    }
}


