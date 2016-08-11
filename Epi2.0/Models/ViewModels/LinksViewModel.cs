using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models.ViewModels
{
    public class LinksViewModel
    {
        public IEnumerable<LinkDetails> LinksList { get; set; }
    }
}