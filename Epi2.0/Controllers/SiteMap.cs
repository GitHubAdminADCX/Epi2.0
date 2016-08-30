using System;
using System.Text;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using System.Xml;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.PlugIn;
using EPiServer.SpecializedProperties;
using EPiServer.Web.Hosting;
using System.Collections.Generic;
using EPiServer.Framework.Localization;
using Settings = EPiServer.Configuration.Settings;

namespace WebClient.Controllers
{
    //FRM036
    [ScheduledPlugIn(DisplayName = "SiteMap schedule", LanguagePath = "/createsitemap", SortIndex = 1)]
    public class SiteMap
    {
        #region "----------------------- Variable declaration -----------------------"

        private static String BaseURL = String.Empty;

        private struct ModuleSettings
        {
            public String Path;
            public String TimeFormat;
            public String PageIds;
            public String DemoPageId;
        }

        #endregion

        #region "----------------------- Properties -----------------------"

        [PlugInProperty(AdminControl = typeof(TextBox), AdminControlValue = "Text", DisplayName = "Extra root page id-s", Description = "Add extra root page id-s separated with ';'. The main root page is indexed automatically!")]
        public String PageIds
        {
            get;
            set;
        }

        [PlugInProperty(AdminControl = typeof(TextBox), AdminControlValue = "Text", DisplayName = "Demo page id", Description = "This is the demo root page id for demonstration content. OBS! Use only one integer PageId here!")]
        public String DemoPageId
        {
            get;
            set;
        }

        [PlugInProperty(AdminControl = typeof(TextBox), AdminControlValue = "Text", LanguagePath = "/sitemapsettings/path")]
        public String Path
        {
            get;
            set;
        }

        [PlugInProperty(AdminControl = typeof(TextBox), AdminControlValue = "Text", LanguagePath = "/sitemapsettings/timeformat")]
        public String TimeFormat
        {
            get;
            set;
        }


        #endregion

        private static String GetBaseUrl()
        {
            String url = Settings.Instance.SiteUrl.ToString();

            if (url.EndsWith("/"))
            {
                return url.Remove(url.LastIndexOf("/"));
            }
            else
            {
                return url;
            }
        }

        private static String GetFriendlyURL(PageData pData, string sLanguage, string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                baseUrl = BaseURL;

            UrlBuilder objUrilBuilder = new UrlBuilder(EPiServer.UriSupport.AddLanguageSelection(pData.LinkURL, sLanguage));

            EPiServer.Global.UrlRewriteProvider.ConvertToExternal(objUrilBuilder, pData.PageLink, System.Text.UTF8Encoding.UTF8);

            if (objUrilBuilder.ToString().Contains("http://"))
                return objUrilBuilder.ToString();

            return baseUrl + objUrilBuilder.ToString();
        }

        private static PageDataCollection GetPages(PageReference root)
        {
            //PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();

            //PropertyCriteria category = new PropertyCriteria();
            //category.Condition = CompareCondition.NotEqual;
            //category.Value = "-1";
            //category.Type = PropertyDataType.PageType;
            //category.Required = true;
            //category.Name = "PageTypeID";

            //criterias.Add(category);

            if (!string.IsNullOrEmpty(SiteConfig.Instance.AdminUserName))
            {
                EPiServer.Security.PrincipalInfo.CurrentPrincipal =
                    EPiServer.Security.PrincipalInfo.CreatePrincipal(SiteConfig.Instance.AdminUserName);
            }
            //			PageDataCollection objCollection = DataFactory.Instance.FindPagesWithCriteria(root, criterias, EPiServer.Security.AccessLevel.NoAccess);

            PageDataCollection objCollection = new PageDataCollection();
            IList<PageReference> prList = DataFactory.Instance.GetDescendents(new PageReference(1));
            foreach (PageReference pr in prList)
            {
                PageData pd = null;
                try
                {
                    pd = DataFactory.Instance.GetPage(pr);
                    if (pd.CheckPublishedStatus(PagePublishedStatus.Published) == true)
                    {
                        objCollection.Add(pd);

                    }
                }
                catch (Exception)
                {

                }
            }

            FilterForVisitor.Filter(objCollection);

            return objCollection;
        }

        private static Int32 CreateXMLSitemap(int[] rootPages, String path, String timeFormat, string baseUrl)
        {
            BaseURL = GetBaseUrl();

            String sTimeFormat = timeFormat != String.Empty ? timeFormat : "yyyy-MM-dd";

            PageDataCollection objCollection = new PageDataCollection();

            foreach (int pageId in rootPages)
            {
                // Add root page
                objCollection.Add(DataFactory.Instance.GetPage(new PageReference(pageId)));

                foreach (PageData objPageData in GetPages(new PageReference(pageId)))
                {


                    if (objPageData["PageShortcutType"] == null ||
                        (objPageData["PageShortcutType"] != null &&
                        ((EPiServer.Core.PageShortcutType)objPageData["PageShortcutType"]) != PageShortcutType.External))
                    {
                        objCollection.Add(objPageData);
                    }
                }
            }

            if (objCollection.Count == 0)
                return -1;

            XmlDocument xDoc = new XmlDocument();

            XmlNode xNode = xDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xDoc.AppendChild(xNode);

            XmlNode xUrlSet = xDoc.CreateElement("urlset");
            XmlAttribute xXMLNS = xDoc.CreateAttribute("xmlns");
            xXMLNS.Value = "http://www.sitemaps.org/schemas/sitemap/0.9";
            xUrlSet.Attributes.Append(xXMLNS);
            xDoc.AppendChild(xUrlSet);

            Int32 iCounter = 0;

            foreach (PageData objPageData in objCollection)
            {
                foreach (String sLanguage in objPageData.PageLanguages)
                {
                    XmlNode xURLNode = xDoc.CreateElement("url");
                    XmlNode xLoc = xDoc.CreateElement("loc");
                    string friendlyURL = GetFriendlyURL(objPageData, sLanguage, baseUrl);

                    XmlNode xURL = xDoc.CreateTextNode(friendlyURL);



                    xLoc.AppendChild(xURL);
                    xURLNode.AppendChild(xLoc);
                    xUrlSet.AppendChild(xURLNode);



                    XmlNode xPrio = xDoc.CreateElement("priority");

                    string url = xURL.InnerText;

                    if (iCounter == 0)
                    {
                        xPrio.AppendChild(xDoc.CreateTextNode("1.000"));
                    }
                    //else if (xURL.InnerText == BaseURL + "/Behandlingsstod/" || xURL.InnerText == BaseURL + "/Patientadministration/" || xURL.InnerText == BaseURL + "/AvtalUppdrag/" || xURL.InnerText == BaseURL + "/utbildningutveckling/" || xURL.InnerText == BaseURL + "/AvtalUppdrag/IT-stod-och-e-tjanster/" || xURL.InnerText == BaseURL + "/Nyheter/Prenumerera/")
                    //{
                    //    xPrio.AppendChild(xDoc.CreateTextNode("0.9000"));
                    //}
                    else
                    {
                        xPrio.AppendChild(xDoc.CreateTextNode("0.5000"));
                    }

                    xURLNode.AppendChild(xPrio);



                    iCounter++;
                }
            }

            xDoc.Save(path);
            //xDoc.Save(@"C:\inetpub\wwwroot\VGG7.local\web\sitemap.xml");


            return iCounter;
        }

        private static ModuleSettings GetSettings()
        {
            SiteMap objSitemap = new SiteMap();
            PlugInSettings.AutoPopulate(objSitemap);

            if (!isValidRoot(objSitemap.Path))
            {
                objSitemap.Path = EPiServer.Global.BaseDirectory.Replace("/", "\\");
            }

            ModuleSettings objSettings = new ModuleSettings();

            objSettings.Path = objSitemap.Path;
            objSettings.TimeFormat = objSitemap.TimeFormat;
            objSettings.PageIds = objSitemap.PageIds;
            objSettings.DemoPageId = objSitemap.DemoPageId;


            return objSettings;
        }

        private static bool isValidRoot(string physicalPath)
        {
            if (string.IsNullOrWhiteSpace(physicalPath))
            {
                return false;
            }
            return System.IO.Directory.Exists(physicalPath);
        }

        public static String Execute()
        {
            //ContentLanguage.PreferredCulture = new System.Globalization.CultureInfo("sv-SE");
            //EPiServer.BaseLibrary.Context.Current["EPiServer:ContentLanguage"] = new System.Globalization.CultureInfo("sv-SE");

            ModuleSettings objSettings = GetSettings();
            //return "test";
            StringBuilder resultMessage = new StringBuilder();

            #region Create live sitemap
            if (String.IsNullOrEmpty(objSettings.Path))
                throw new Exception(LocalizationService.Current.GetString("/createsitemap/errpathnotset"));

            List<int> pageIds = new List<int>();
            pageIds.Add(PageReference.RootPage.ID);

            if (!string.IsNullOrEmpty(objSettings.PageIds))
            {
                string[] strIdList = objSettings.PageIds.Split(';');
                if (strIdList != null)
                {
                    foreach (string strId in strIdList)
                    {
                        int id = 0;
                        int.TryParse(strId, out id);
                        if (id != 0)
                        {
                            pageIds.Add(id);
                        }
                    }
                }
            }


            Int32 urlXMLSite = CreateXMLSitemap(
                pageIds.ToArray(),
                objSettings.Path + "sitemap.xml",
                objSettings.TimeFormat,
                null);




            // Create page list for notify
            //string url = Settings.Instance.SiteUrl.AbsoluteUri;
            //List<Uri> uris = SiteSeekerHelper.ExtractUriListFromHtmlMap(url + "sitemap.html", false);

            //List<Uri> uriDocs = SiteSeekerHelper.ExtractUriListFromHtmlMap(url + "sitemapdocs.html", false);
            //uriDocs.ForEach(uris.Add);

            //// Create documents list for notify
            //NotifySearchIndex notifyIndex = SearchIndexFactory.GetNotifySearchIndex(SiteConfig.Instance.GetSearchIndex(SiteSeekerIndexes.CommonIndex).Name);
            //notifyIndex.Notify(uris.ToArray());

            //notifyIndex = SearchIndexFactory.GetNotifySearchIndex(SiteConfig.Instance.GetSearchIndex(SiteSeekerIndexes.EpiSite).Name);
            //notifyIndex.Notify(uris.ToArray());

            #endregion

            #region Create demo sitemap (full site, together with the demo node id)
            int demoId = 0;
            int.TryParse(objSettings.DemoPageId, out demoId);
            if (demoId != 0)
            {
                pageIds.Add(demoId);
            }



            //notifyIndex = SearchIndexFactory.GetNotifySearchIndex(SiteConfig.Instance.GetSearchIndex(SiteSeekerIndexes.EpiSiteDemo).Name);
            //url = Settings.Instance.SiteUrl.AbsoluteUri;
            //uris = SiteSeekerHelper.ExtractUriListFromHtmlMap(url + "sitemapdemo.html", false);
            //notifyIndex.Notify(uris.ToArray());

            #endregion

            if (urlXMLSite != -1)
                resultMessage.AppendFormat(LocalizationService.Current.GetString("/createsitemap/message"), urlXMLSite, objSettings.Path + "sitemap.html; ");




            resultMessage.AppendFormat("; User: " + SiteConfig.Instance.AdminUserName);

            return resultMessage.ToString();
        }


    }
}