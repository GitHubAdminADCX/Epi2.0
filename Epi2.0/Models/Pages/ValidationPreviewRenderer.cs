using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Epi2._0.Models.Custom.Attributes;
using EPiServer;
using EPiServer.Shell.ObjectEditing;
using WebClient.HelperClass;
using EPiServer.Web;

namespace WebClient.Models.Pages
{
    [ContentType(DisplayName = "ValidationPreviewRenderer", GUID = "E46B8E35-0F07-431D-BF7F-B9F9622797C0", Description = "This is a standard page type model")]
    public class ValidationPreviewRenderer:PageData
    {

        [Display(
           Name = "Main body",
           Description = "",
           GroupName = SystemTabNames.Content,
           Order = 1)]
        // [ValidationProperty]
        public virtual XhtmlString MainBody { get; set; }


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
        //FRM019:custom property editor 
        [AutoSuggestSelection(typeof(MySelectionQuery), AllowCustomValues = true)]
      //  [ValidationProperty]       
        public virtual string stringproperty { get; set; }

        [CultureSpecific]
        [Required]
        [Display(
               Name = "ContentReferencetest",
               Description = "ContentReferencetest",
               GroupName = SystemTabNames.Content,
               Order = 9)]
      //  [UIHint(UIHint.Image)]
        public virtual ContentReference BannerImage { get; set; }

        [Editable(true)]
        [Display(
          Name = "PageReferencetest",
          Description = "PageReferencetest",
          GroupName = SystemTabNames.Content,
          Order = 98)]
        public virtual PageReference NewsPagesEnglishPageReference { get; set; }

        //[PageTypeProperty(EditCaption = "Tags",
        //    Type = typeof(PropertyCategoryCheckBoxList),
        //    HelpText = "ArticleRoot",
        //    SortOrder = 100,
        //    Tab = typeof(ArticlesTab))]
        //public virtual string TagIds { get; set; }

      


    }
}