using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using WebClient.Customization.CustomProperties;
using System.Collections.Generic;
using WebClient.Models.ViewModels;

namespace WebClient.Models.Blocks
{
    [ContentType(DisplayName = "LinkPropertyBlock", GUID = "ddcbc426-a750-4a18-aed0-cd15a1037821", Description = "")]
    public class LinkPropertyBlock : BlockData
    {
        [UIHint("LinksProperty")]
        [Display(
             Name = "",
             Description = "",
             Order = 25)]
        [BackingType(typeof(PropertyCustomLink))]
        public virtual IEnumerable<LinkDetails> LinksList { get; set; }
    }
}