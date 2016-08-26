using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.Models.Pages;

namespace WebClient.Models.ViewModels
{
    public class ArticleViewModel
    {
        public ArticlePageType articlePage { get; set; }
        public string MainBody { get; set; }
        public LinksViewModel LinksList { get; set; }
    }
}