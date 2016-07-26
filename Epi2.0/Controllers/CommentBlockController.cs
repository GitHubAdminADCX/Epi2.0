using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class CommentBlockController : BlockController<CommentBlock>
    {
        private PageRouteHelper _pageRouteHelper;
        //private int _pageId;



        public CommentBlockController()
        {
            _pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
            //_pageId = _pageRouteHelper.ContentLink.ID;
        }

        // GET: CommentBlock
        public override ActionResult Index(CommentBlock currentBlock)
        {
            var a = _pageRouteHelper.ContentLink.ID;
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
                commentblockproperties = currentBlock,
                pageId = pageId,
                Comments = list,
                Page = Page,
                pageURl = PageURl.VirtualPath.ToString()
            };
            //var model = BlockViewModel.Create(currentBlock);
            //return PartialView();
            return View(model);
        }

        [HttpPost]
        public ActionResult Addcomment(int pageId,string commentText,string urlstring, string commentId)
        {

            var d  = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();

            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            var comment = new Comment()
            {
                CommentId = Guid.NewGuid().ToString(),
                CommentText = commentText,
                Date = DateTime.Now,
                UserName = "AP",
                PageId = pageId,
                IsCommentDeleted = false,
                ParentCommentId= commentId == "" ? "" : commentId

            };

            commentStore.Save(comment);


            //_commentService.AddComment(pageId, _communityService.CurrentUser.UserName, commentText);
            //_noticeCommandService.SaveNoticeSettingForPage(pageId, false, _communityService.CurrentUser.UserName);
            //_cacheService.Remove(String.Format("{0}{1}", CacheKeys.CommentsForNewsPage, pageId));
            //_cacheService.Remove(String.Format("{0}{1}", CacheKeys.ColleaguesForNewsPage, pageId));
            //return RedirectToAction("Index");
            return Redirect("~/"+urlstring+"");
        }

        public ActionResult RenderReplyPartialView(string ParentCommentId)
        {

            return PartialView("~/Views/ReplyToComment/Index.cshtml", ParentCommentId);
        }

        public ActionResult GetAllChildComments(string ParentCommentId)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            var er = commentStore.Items<Comment>();
            var query = from comments in er
                        where comments.ParentCommentId == ParentCommentId
                        orderby comments.Date ascending
                        select comments;
            var list = query.ToList<Comment>();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}