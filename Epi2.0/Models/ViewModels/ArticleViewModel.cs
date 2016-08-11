using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models.ViewModels
{
    public class ArticleViewModel
    {
        public string MainBody { get; set; }
        public LinksViewModel LinksList { get; set; }
    }
}