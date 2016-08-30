using EPiServer.Framework;
using System;
using EPiServer.Framework.Initialization;
using WebClient.Models.Pages;
using EPiServer;
using System.Linq;
using EPiServer.Logging.Compatibility;
using WebClient.Business.Entities.DDS;
using EPiServer.Data.Dynamic;
using System.Net.Mail;
using System.Net;
using System.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System.Web.Mvc;

namespace WebClient.HelperClass
{
    //id :- FRM013
    ///Author:Kunal Doshi
    /// This his a helper class to send mail
    /// Here the publishing event is traced using by Inheriting from "IInitializableModule"
    /// Also present here is SMTP configuration to send mails


    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MailHelper : IInitializableModule
    {
        private bool _eventsAttached = false;
        private static readonly ILog Log = LogManager.GetLogger(typeof(MailHelper));
        public void Initialize(InitializationEngine context)
        {
            if (!_eventsAttached)
            {
                //TODO: Cant find out how to do this using the repo
                DataFactory.Instance.PublishingContent += OnPublishingContent;
                _eventsAttached = true;
            }
        }


        public void OnPublishingContent(object sender, ContentEventArgs e)
        {
            try
            {
                StandardPageType standardPageType = e.Content as StandardPageType;

                if (standardPageType != null)
                {
                    sendMails(standardPageType);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in OnPublishingContent method in StandardPageType class.", ex);
                throw;
            }

        }

        public void sendMails(StandardPageType standardPageType)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Mail));
            var allData = commentStore.Items<DDS_Mail>();

            var query = from sendTo in allData
                        select sendTo;
            var list = query.ToList();

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("episerverframwork@gmail.com");
                foreach (var senditems in list)
                {
                    mail.To.Add(senditems.SendToMail);
                }

                mail.Subject = "New Content published";

                var urlHelper = ServiceLocator.Current.GetInstance<UrlHelper>();
                var friendlyUrl = urlHelper.RequestContext.HttpContext.Request.Url.ToString().Substring(0, 17);

                string urlpath = "<a href='" + friendlyUrl + standardPageType.Language + "/" + standardPageType.URLSegment + "'>Click Here</a>";
                mail.Body = "<h1>Hello</h1> </br></br> Please find the new content in the link given below </br>" + urlpath;

                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("episerverframwork@gmail.com", "Capgemini!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }


        public void Uninitialize(InitializationEngine context)
        {
            // Detach event handlers
            DataFactory.Instance.PublishingPage -= OnPublishingContent;
        }
    }
}
