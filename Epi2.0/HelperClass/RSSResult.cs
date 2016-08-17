using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace WebClient.HelperClass
{
    /// ID :FRM007
    ///Author:Kunal Doshi
    ///Purpose of the Class :A simple feed generator which generates XML ,and can be consume on a page
    ///Dependent entities : Helper Class  RSSResult, SyndicationFeed (Meta).Rss20FeedFormatter (Meta) ,XmlWriter 
    ///How to use: 1. Create a Page type ,add a property Eg PageReference type
    ///            2. Create a controller inherit the page from the controller
    ///            3. Use a list and add elemnts of SyndicationItem class 
    ///            4. Create a helper class (RSSResult) that will convert the incoming data to Rss XML format and passes it to the contoller
    //
    ///            
    ///            
    ///Points to take care:
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>

    public class RSSResult :ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public RSSResult() { }

        public RSSResult(SyndicationFeed feed)
        {
            this.Feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            Rss20FeedFormatter formatter = new Rss20FeedFormatter(this.Feed);

            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}