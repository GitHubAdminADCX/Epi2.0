using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebClient.Models.Blocks
{
    //FRM011
    [ContentType(DisplayName = "MenuTree", GUID = "53ebee05-ade2-41df-a1bd-733c3b53436d", Description = "")]
    public class MenuTree : BlockData
    {
        [Display(Name = "Parent Reference",
        Description = "Parent reference here.",
        Order = 1)]
        public virtual PageReference Parentreference { get; set; }
    }
}