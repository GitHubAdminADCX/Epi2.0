using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Shell.WebForms;
using EPiServer.BaseLibrary.Scheduling;
using EPiServer;
using EPiServer.Filters;
using System.Configuration;
using EPiServer.ServiceLocation;
using System.Web.WebPages;
using System.Linq;
using EPiServer.Security;
using EPiServer.DataAccess;

namespace WebClient.Models.Pages
{

    ///Author:Amol Pawar
    ///Purpose of the Class :A Custom schedule job will help to move pages which match specific condition(datetime condition, specific type of pages,etc.) to desired folder/location for user efficiency.
    ///                      This is Episerver schedule job.
    ///Dependent entities :  ArchivePagesJob.cs(schedule job), web.config(to set certain keys value.
    ///How to use: 1.Create a class as ArchivePagesJob.cs which will inherit to JobBase.
    ///            2. Override Execute() method.
    ///            3. GetPagesUnfiltered() is the method to implement business logic.
    ///


    [EPiServer.PlugIn.ScheduledPlugIn(
    DisplayName = "Archive Job",
    Description = "Archive Job",
  
    SortIndex = 1000)]

    //[ContentType(DisplayName = "ArchivePages", GUID = "b245a1f4-4164-4407-8adc-1d79040655a9", Description = "")]
    public class ArchivePagesJob : JobBase
    {
        private bool _stopSignaled;

        //public void DeleteJob()
        //{
        //    IsStoppable = true;
        //}

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Logic for deletion
        /// </summary>
        /// <returns></returns>
        public override string Execute()
        {
            string resultMessage = string.Empty;
            // set value to number of month old pages
            DateTime dt = DateTime.Now.AddMonths(-(2));

            GetPagesUnfiltered(dt);
            //GetListPagesUnfiltered(dt);
            resultMessage = "The Job Executed successfully:";
            return resultMessage;
        }


        protected string GetPagesUnfiltered(DateTime since)
        {
            PropertyCriteriaCollection col = new PropertyCriteriaCollection();
            PageData pageroot;

            //Restrict Pagetypes
            var repository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.DataAbstraction.PageTypeRepository>();


            //Start : for News Page page

            //For Fetching the News Page
            PropertyCriteria criteria = new PropertyCriteria();
            //criteria = new PropertyCriteria();
            criteria.Condition = CompareCondition.Equal;
            criteria.Name = "PageTypeID";
            criteria.Type = PropertyDataType.PageType;
            // set pagetype to be deleted
            criteria.Value = repository.Load(typeof(PropertiesSeperator)).ID.ToString();
            //criteria.Required = true;
            col.Add(criteria);

            //Fetching News Page with Date Criteria
            PropertyCriteria criteria1 = new PropertyCriteria();
            //criteria = new PropertyCriteria();
            criteria1.Condition = CompareCondition.LessThan;
            criteria1.Name = "PageCreated";
            criteria1.Type = PropertyDataType.Date;
            criteria1.Value = since.ToString();
            criteria.Required = true;
            col.Add(criteria1);
            //End : for News page
            // find key in config file
            PageDataCollection pageList = DataFactory.Instance.FindPagesWithCriteria(new PageReference(ConfigurationManager.AppSettings["ArchiveStartPage"]), col);



            // return pageList;
            //Check if there is any pages that matches the criteria
            if (pageList.Count >= 1)
            {

                //Creating the folder with reference to the start page
                //PageReference parent = new PageReference(ConfigurationManager.AppSettings["DestinationRootFolder"]);
                PageReference parent = new PageReference(1);
                PropertiesSeperator containerPage = DataFactory.Instance.GetDefault<PropertiesSeperator>(parent);
                //containerPage.PageName = ConfigurationManager.AppSettings["DestinationfolderName"];
                containerPage.PageName = ConfigurationManager.AppSettings["DestinationfolderName"];
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

                //var startPage = contentRepository.Get<StartPage>(ContentReference.StartPage);
                var repository1 = ServiceLocator.Current.GetInstance<IContentRepository>();
                PageDataCollection children = DataFactory.Instance.GetChildren(parent);


                //Check if the Destinationfolder exist 
                var RootFolder = children.Where(p => p.Name == ConfigurationManager.AppSettings["DestinationfolderName"] && p.PageTypeName == typeof(PropertiesSeperator).Name);


                //If destination folder does not exist than create the folder
                if (RootFolder.Count() < 1)
                {
                    var PublishRootFolder = DataFactory.Instance.Save(containerPage, SaveAction.Publish, AccessLevel.NoAccess);
                    pageroot = new PageData(PublishRootFolder);
                }
                else
                {
                    pageroot = RootFolder.FirstOrDefault();
                }

                PageDataCollection children1 = DataFactory.Instance.GetChildren(pageroot.ContentLink as PageReference);

                //looping through each page which are 6 months older 
                foreach (var page in pageList)
                {

                    var year = page.Created.Year;
                    var Yearcheck = DataFactory.Instance.GetChildren(pageroot.ContentLink as PageReference);
                    var existyr = Yearcheck.Where(p => p.Name == year.ToString() && p.PageTypeName == typeof(PropertiesSeperator).Name);
                    //if year does not exist than create the year
                    if (existyr.Count() < 1)
                    {
                        PropertiesSeperator containerPage1 = DataFactory.Instance.GetDefault<PropertiesSeperator>(pageroot.ContentLink as PageReference);
                        containerPage1.PageName = year.ToString();
                        var savedyr = DataFactory.Instance.Save(containerPage1, SaveAction.Publish, AccessLevel.NoAccess);
                        var month = page.Created.Month;

                        int iMonthNo = month;
                        DateTime dtDate = new DateTime(2000, iMonthNo, 1);
                        string sMonthFullName = dtDate.ToString("MMMM");

                        PropertiesSeperator containerPage2 = DataFactory.Instance.GetDefault<PropertiesSeperator>(savedyr);
                        containerPage2.PageName = sMonthFullName.ToString();
                        var savedmonth = DataFactory.Instance.Save(containerPage2, SaveAction.Publish, AccessLevel.NoAccess);

                        DataFactory.Instance.Move(page.ContentLink as PageReference, savedmonth);
                    }
                    else {
                        var pagemonth = page.Created.Month;

                        int iMonthNo = pagemonth;
                        DateTime dtDate = new DateTime(2000, iMonthNo, 1);
                        string sMonthFullName = dtDate.ToString("MMMM");

                        var Monthcheck = DataFactory.Instance.GetChildren(existyr.FirstOrDefault().ContentLink as PageReference);
                        var existMONTH = Monthcheck.Where(p => p.Name == sMonthFullName.ToString() && p.PageTypeName == typeof(PropertiesSeperator).Name);
                        //check if month exist
                        if (existMONTH.Count() < 1)
                        {
                            PropertiesSeperator containerPage3 = DataFactory.Instance.GetDefault<PropertiesSeperator>(existyr.FirstOrDefault().ContentLink as PageReference);
                            containerPage3.PageName = sMonthFullName.ToString();
                            var curretnsaveddmonth = DataFactory.Instance.Save(containerPage3, SaveAction.Publish, AccessLevel.NoAccess);
                            DataFactory.Instance.Move(page.ContentLink as PageReference, curretnsaveddmonth);
                        }
                        else {
                            DataFactory.Instance.Move(page.ContentLink as PageReference, existMONTH.FirstOrDefault().ContentLink as PageReference);


                        }

                    }

                }

                //Delete 15 months older pages
                //DateTime delete = DateTime.Now.AddMonths(-15);

                //PropertyCriteriaCollection listpagepropdelete = new PropertyCriteriaCollection();
                //PropertyCriteria Listcriteriadelete = new PropertyCriteria();
                //Listcriteriadelete.Condition = CompareCondition.LessThan;
                //Listcriteriadelete.Name = "PageCreated";
                //Listcriteriadelete.Type = PropertyDataType.Date;
                //Listcriteriadelete.Value = delete.ToString();
                //Listcriteriadelete.Required = true;
                //listpagepropdelete.Add(Listcriteriadelete);

                //PageDataCollection pageListForNewsPageDelete = DataFactory.Instance.FindPagesWithCriteria(pageroot.ContentLink as PageReference, listpagepropdelete);
                //foreach (var pageDelete in pageListForNewsPageDelete)
                //{
                //    DataFactory.Instance.Delete(pageDelete.ContentLink, true);
                //}


                return "Job Executed successfully";

            }
            return "There are no pages to move";
        }

        //protected string GetListPagesUnfiltered(DateTime since)
        //{
        //    PropertyCriteriaCollection listpageprop = new PropertyCriteriaCollection();
        //    var ListPagerepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.DataAbstraction.PageTypeRepository>();
        //    //Start : for list page

        //    PropertyCriteria Listcriteria = new PropertyCriteria();
        //    Listcriteria.Condition = CompareCondition.Equal;
        //    Listcriteria.Name = "PageTypeID";
        //    Listcriteria.Type = PropertyDataType.PageType;
        //    Listcriteria.Value = ListPagerepository.Load(typeof(PropertiesSeperator)).ID.ToString();
        //    //Listcriteria.Required = true;
        //    listpageprop.Add(Listcriteria);


        //    PropertyCriteria Listcriteria1 = new PropertyCriteria();
        //    Listcriteria1.Condition = CompareCondition.LessThan;
        //    Listcriteria1.Name = "PageCreated";
        //    Listcriteria1.Type = PropertyDataType.Date;
        //    Listcriteria1.Value = since.ToString();
        //    Listcriteria.Required = true;
        //    listpageprop.Add(Listcriteria1);

        //    PageDataCollection pageListForListPage = DataFactory.Instance.FindPagesWithCriteria(new PageReference(ConfigurationManager.AppSettings["ListArchiveStartPage"]), listpageprop);
        //    //End : for list page

        //    if (pageListForListPage.Count >= 1)
        //    {
        //        PageReference parent = new PageReference(ConfigurationManager.AppSettings["DestinationRootFolder"]);
        //        PropertiesSeperator containerPage = DataFactory.Instance.GetDefault<PropertiesSeperator>(parent);
        //        containerPage.PageName = ConfigurationManager.AppSettings["ListDestinationfolderName"];
        //        var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
        //        //var startPage = contentRepository.Get<StartPage>(ContentReference.StartPage);
        //        //var repository1 = ServiceLocator.Current.GetInstance<IContentRepository>();
        //        PageDataCollection children = DataFactory.Instance.GetChildren(parent);


        //        //Check if the Destinationfolder exist 
        //        var RootFolder = children.Where(p => p.Name == ConfigurationManager.AppSettings["ListDestinationfolderName"] && p.PageTypeName == typeof(ContainerPage).Name);
        //        PageData pageroot;

        //        if (RootFolder.Count() < 1)
        //        {
        //            var PublishRootFolder = DataFactory.Instance.Save(containerPage, SaveAction.Publish, AccessLevel.NoAccess);
        //            pageroot = new PageData(PublishRootFolder);
        //        }
        //        else
        //        {
        //            pageroot = RootFolder.FirstOrDefault();
        //        }

        //        PageDataCollection children1 = DataFactory.Instance.GetChildren(pageroot.ContentLink as PageReference);

        //        foreach (var page in pageListForListPage)
        //        {

        //            var year = page.Created.Year;
        //            var Yearcheck = DataFactory.Instance.GetChildren(pageroot.ContentLink as PageReference);
        //            var existyr = Yearcheck.Where(p => p.Name == year.ToString() && p.PageTypeName == typeof(PropertiesSeperator).Name);
        //            //if year does not exist than create the year
        //            if (existyr.Count() < 1)
        //            {
        //                PropertiesSeperator containerPage1 = DataFactory.Instance.GetDefault<PropertiesSeperator>(pageroot.ContentLink as PageReference);
        //                containerPage1.PageName = year.ToString();
        //                var savedyr = DataFactory.Instance.Save(containerPage1, SaveAction.Publish, AccessLevel.NoAccess);
        //                var month = page.Created.Month;

        //                int iMonthNo = month;
        //                DateTime dtDate = new DateTime(2000, iMonthNo, 1);
        //                string sMonthFullName = dtDate.ToString("MMMM");

        //                PropertiesSeperator containerPage2 = DataFactory.Instance.GetDefault<PropertiesSeperator>(savedyr);
        //                containerPage2.PageName = sMonthFullName.ToString();
        //                var savedmonth = DataFactory.Instance.Save(containerPage2, SaveAction.Publish, AccessLevel.NoAccess);

        //                DataFactory.Instance.Move(page.ContentLink as PageReference, savedmonth);
        //            }
        //            else {
        //                var pagemonth = page.Created.Month;

        //                int iMonthNo = pagemonth;
        //                DateTime dtDate = new DateTime(2000, iMonthNo, 1);
        //                string sMonthFullName = dtDate.ToString("MMMM");

        //                var Monthcheck = DataFactory.Instance.GetChildren(existyr.FirstOrDefault().ContentLink as PageReference);
        //                var existMONTH = Monthcheck.Where(p => p.Name == sMonthFullName.ToString() && p.PageTypeName == typeof(PropertiesSeperator).Name);
        //                //check if month exist
        //                if (existMONTH.Count() < 1)
        //                {
        //                    PropertiesSeperator containerPage3 = DataFactory.Instance.GetDefault<PropertiesSeperator>(existyr.FirstOrDefault().ContentLink as PageReference);
        //                    containerPage3.PageName = sMonthFullName.ToString();
        //                    var curretnsaveddmonth = DataFactory.Instance.Save(containerPage3, SaveAction.Publish, AccessLevel.NoAccess);
        //                    DataFactory.Instance.Move(page.ContentLink as PageReference, curretnsaveddmonth);
        //                }
        //                else {
        //                    DataFactory.Instance.Move(page.ContentLink as PageReference, existMONTH.FirstOrDefault().ContentLink as PageReference);

        //                }

        //            }

        //        }

        //        DateTime delete = DateTime.Now.AddMonths(-15);

        //        PropertyCriteriaCollection listpagepropdelete = new PropertyCriteriaCollection();
        //        PropertyCriteria Listcriteriadelete = new PropertyCriteria();
        //        Listcriteriadelete.Condition = CompareCondition.LessThan;
        //        Listcriteriadelete.Name = "PageCreated";
        //        Listcriteriadelete.Type = PropertyDataType.Date;
        //        Listcriteriadelete.Value = delete.ToString();
        //        Listcriteriadelete.Required = true;
        //        listpagepropdelete.Add(Listcriteriadelete);

        //        PageDataCollection pageListForListPageDelete = DataFactory.Instance.FindPagesWithCriteria(pageroot.ContentLink as PageReference, listpagepropdelete);
        //        foreach (var pageDelete in pageListForListPageDelete)
        //        {
        //            DataFactory.Instance.Delete(pageDelete.ContentLink, true);
        //        }


        //        return "Job Executed successfully";


        //    }
        //    return "There are no pages to move";
        //}


    }
}