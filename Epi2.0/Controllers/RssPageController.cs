using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebClient.Models.Pages;
using WebClient.Models.ViewModels;
using System.ServiceModel.Syndication;
using WebClient.HelperClass;

namespace WebClient.Controllers
{
    /// ID :FRM007
    ///Author:Kunal Doshi
    public class RssPageController : PageController<RssPage>
    {
        public ActionResult Index(RssPage currentPage)
        {
            string pageChild = string.Empty;
            string Createdby = string.Empty;

            var pageChildren = Enumerable.Empty<PageData>();

            // Get the content repository
            IContentRepository contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();

            // Get the children of the page specified in the ParentPage property of the block
            if (!PageReference.IsNullOrEmpty(currentPage.ParentPage))
            {
                pageChildren = contentRepository.GetChildren<PageData>(currentPage.ParentPage);
            }
           
            List<SyndicationItem> list = new List<SyndicationItem>();


            foreach (var info in pageChildren)
            {
                pageChild = info.Name;
                Createdby = info.CreatedBy;
                list.Add(new SyndicationItem(Createdby, pageChild, null));
            }

            SyndicationFeed feed = new SyndicationFeed(list);


            return new RSSResult(feed);

        }
    }
}