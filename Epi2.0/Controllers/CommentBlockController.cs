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
    ///FRM010
    /// Author:Amol Pawar
    ///Purpose of the Class :Generic Functionality(block) to Comment on any type of page with the use of CommentBlock.
    ///Dependent entities : CommentBlock, Pagetype where block can be render,CommentBlockController,Comment.cs,CommentViewModel.cs,DDSComment,CommentService.svc
    ///How to use: 1. Create blockType, controller for block and its view.
    ///            2. Add contentArea in page where we can render this block.
    ///            3. Create DDS table and its class to map the DDS table(Comment.cs)
    ///            4. Create Service to implement the module's logic(CommentService.svc),Check the end points created in web.config, if require do changes in web.config as needed under <system.serviceModel>

    ///Points to take care: 
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>
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