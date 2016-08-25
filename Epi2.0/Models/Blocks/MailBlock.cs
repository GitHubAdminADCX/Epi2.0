using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebClient.Models.Blocks
{
    [ContentType(DisplayName = "MailBlock", GUID = "aa374621-45b6-4cea-b347-73203ba5f7c5", Description = "")]
    public class MailBlock : BlockData
    {
        [Display(Name = "Send From",
             Description = "A block that lists latest books.",
             Order = 1)]
        public virtual string From { get; set; }

        
        [Display(Name = "Send To",
        Description = "A block that lists latest books.",
        Order = 1)]
        public virtual string SendTo { get; set; }
    }
}