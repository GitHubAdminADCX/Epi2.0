using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Pages;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class AdminToolLocationController : Controller
    {
        // GET: AdminToolLocation
        // GET: AdminToolLocation
        public ActionResult Index()
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Location));
            var allData = commentStore.Items<DDS_Location>();
            var query = from sendmail in allData
                        select sendmail;
            var list = query.ToList<DDS_Location>();

            string sendstring = string.Empty;
            foreach (var places in list)
            {
                sendstring = sendstring + ";" + places.RegionName;
            }
            var model = new AdminLocation()
            {
                RegionName = sendstring,
            };
            return View(model);
        }

        public ActionResult AddLocation(string location, string RegionCode, string CountryCode, string CountryName)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Location));
            var comment = new DDS_Location()
            {
                RegionName = location,
                RegionCode = RegionCode,
                CountryName = CountryName,
                CountryCode = CountryCode,


            };
            commentStore.Save(comment);
            var model = new AdminLocation()
            {
                RegionName = "Record Saved",

            };
            return View("Index", model);
        }
    }
}