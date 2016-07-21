using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Epi2._0.Models.Custom.Attributes;
using EPiServer;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "ValidationPreviewRenderer", GUID = "E46B8E35-0F07-431D-BF7F-B9F9622797C0", Description = "This is a standard page type model")]
    public class ValidationPreviewRenderer:PageData
    {

        //[Display(
        //   Name = "Main body",
        //   Description = "",
        //   GroupName = SystemTabNames.Content,
        //   Order = 1)]
        //// [ValidationProperty]
        //public virtual XhtmlString MainBody { get; set; }


        [Display(
          Name = "Content Area",
          Description = "",
          GroupName = SystemTabNames.Content,
          Order = 25)]
        public virtual ContentArea TestContentArea { get; set; }


        [Display(
            Name = "Website url",
             Description = "",
             GroupName = SystemTabNames.Content,
             Order = 91)]
         [ValidationProperty]
        [BackingType(typeof(PropertyUrl))]
        public virtual Url WebSiteUrl { get; set; }

        [Display(
            Name = "Website url12",
             Description = "",
             GroupName = SystemTabNames.Content,
             Order = 90)]
        [ValidationProperty]       
        public virtual string stringproperty { get; set; }


    }
}