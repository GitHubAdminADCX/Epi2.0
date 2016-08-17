using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebClient.Controllers
{
    //FRM036
    public class SiteConfig
    {
        #region Declarations

        private static SiteConfig instance;

        private static string CONFIG_FOLDER = "ConfigSettings";
        private static string CONFIG_FILE = "WebSiteConfig.xml";

        #endregion

        #region Constructors

        private SiteConfig() { }

        #endregion

        #region Properties

        #region XML related properties (here can be added complex structures also)

        /// <summary>
        /// Siteseeker index settings array
        /// </summary>
        public SearchIndex[] SiteSeekerSettings { get; set; }
        public Index[] SearchIndexes { get; set; }

        public string UnitPagePath { get; set; }
        public string PersonPagePath { get; set; }

        /// <summary>
        /// Administrator user name for background jobs
        /// </summary>
        public string AdminUserName { get; set; }

        public ElasticIndex[] ElasticSettings { get; set; }

        #endregion

        public static SiteConfig Instance
        {
            get
            {
                instance = instance ?? (GetSiteSettings() ?? new SiteConfig());

                return instance;
            }
        }

        #endregion

        #region Methods

        public void SaveSiteSettings()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + CONFIG_FOLDER;
            string filename = System.IO.Path.Combine(strPath, CONFIG_FILE);
            XMLClassSerializer.SerializeObject(filename, instance);
        }

        public SearchIndex GetSearchIndex(SiteSeekerIndexes indexName)
        {
            return GetSearchIndex(indexName.ToString());
        }

        public SearchIndex GetSearchIndex(string indexName)
        {
            var sss = new SearchIndex();
            if (instance == null) return sss;
            if (instance.SiteSeekerSettings == null) return sss;

            sss = instance.SiteSeekerSettings.FirstOrDefault(c => c.InternName == indexName);

            return sss;
        }

        public Index GetIndex(string indexName)
        {
            var result = new Index();
            if (instance == null) return result;
            if (instance.SearchIndexes == null) return result;

            result = instance.SearchIndexes.FirstOrDefault(c => c.Name == indexName);

            return result;
        }

        private static SiteConfig GetSiteSettings()
        {
            SiteConfig siteSettings = null;
            var strFilePath = AppDomain.CurrentDomain.BaseDirectory + CONFIG_FOLDER + "\\" + CONFIG_FILE;

            siteSettings = (SiteConfig)XMLClassSerializer.DeSerializeObject<SiteConfig>(strFilePath);

            return siteSettings;
        }


        #endregion
    }

    /// <summary>
    /// Siteseeker setting class
    /// </summary>
    public class SearchIndex
    {
        public string InternName { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }

    public class Index
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }

    /// <summary>
    /// Intern name for indexes
    /// </summary>
    public enum SiteSeekerIndexes
    {
        EpiSite = 0,
        EpiSiteDemo = 50,
        CommonIndex = 100
    }

    /// <summary>
    /// Intern name for indexes
    /// </summary>
    public enum ElasticIndexes
    {
        SiteIndex = 0,
        SiteDemoIndex = 50,
        EkIndex = 100,
        EkIndexNotLoggedIn = 200
    }


    public class ElasticIndex
    {
        public string Default { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
    }
}
