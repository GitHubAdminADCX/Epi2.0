using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClient.Models.Blocks
{
   
    [ContentType(DisplayName = "CommentBlock", GUID = "AAB9E4DF-654B-4205-8715-912A18C33687", Description = "Generic Comment Block")]
    public class CommentBlock : BlockData
    {
        [Display(Name = "UserName",
        Description = "A block that lists latest books.",
        Order = 1)]
        public virtual string Commentexbox { get; set; }
    }
}


