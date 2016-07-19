using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebClient
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        public static class SiteUIHints
        {
            public const string Contact = "contact";
            public const string Strings = "StringList";
        }
    }
   
}