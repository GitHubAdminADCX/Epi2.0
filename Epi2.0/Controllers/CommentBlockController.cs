using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System.Linq;
using System.Web.Mvc;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class CommentBlockController : BlockController<CommentBlock>
    {

        // GET: CommentBlock
        public override ActionResult Index(CommentBlock currentBlock)
        {

            var pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
            var pageId = pageRouteHelper.ContentLink.ID;
            var Page = pageRouteHelper.Page;
            var PageURl = ServiceLocator.Current.GetInstance<UrlResolver>()
                        .GetVirtualPath(pageRouteHelper.ContentLink);

            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            var er = commentStore.Items<Comment>();
            var query = from comments in er
                        where comments.PageId == pageId && (comments.ParentCommentId == null || comments.ParentCommentId == "")
                        orderby comments.Date ascending
                        select comments;
            var list = query.ToList<Comment>();


            var model = new CommentViewModel()
            {
                //commentblockproperties = currentBlock,
                pageId = pageId,
                Comments = list,
                Page = Page,
                pageURl = PageURl.VirtualPath.ToString()
            };
            //var model = BlockViewModel.Create(currentBlock);
            //return PartialView();
            return View(model);
        }

    }
}