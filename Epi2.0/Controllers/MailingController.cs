using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class MailingController : BlockController<MailBlock>
    {
        //id :- FRM013
        ///Author:Kunal Doshi
        ///
        public override ActionResult Index(MailBlock currentBlock)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Mail));
            var allData = commentStore.Items<DDS_Mail>();
            var query = from sendmail in allData
                        select sendmail;
            var list = query.ToList<DDS_Mail>();

            string sendstring = string.Empty;
            foreach (var senditems in list)
            {
                sendstring = sendstring + ";" + senditems.SendToMail;
            }
            var pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
            var pageId = pageRouteHelper.ContentLink.ID;
            var Page = pageRouteHelper.Page;

            var PageURl = ServiceLocator.Current.GetInstance<UrlResolver>()
                                 .GetVirtualPath(pageRouteHelper.ContentLink);


            var model = new MailBlockViewModel()
            {
                mailblock = currentBlock,
                SendTo = sendstring,
                pageURl = PageURl.VirtualPath.ToString()
            };
            return View(model);
        }
        //[HttpPost]
        public ActionResult AddMail(string txtSendTo, string urlstring)

        {
       
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Mail));
            var comment = new DDS_Mail()
            {
                SendToMail = txtSendTo
            };
            commentStore.Save(comment);
            return Redirect("~/" + urlstring + "");

        }


    }
}