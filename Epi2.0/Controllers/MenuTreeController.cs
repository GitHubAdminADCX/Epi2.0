using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models.Blocks;

namespace WebClient.Controllers
{
    //FRM011
    /*The main purpose of this class is to display the menu tree as  displayed in  EpiMenuTree */
    public class MenuTreeController : BlockController<MenuTree>
    {

        // FRM011 This Action is only to Display the logic in BlockType
        public override ActionResult Index(MenuTree currentBlock)
        {
          var menu =   MenuTree(currentBlock);
            //return (menu);
            return View(menu);

        }

        // GET: MenuTree
        /* FRM011 This method gets the whole menutree with the child as loadchild method has been called from this method.
        this method also getts all the pages from root page as per the value given in webconfig file*/
        public JsonResult MenuTree(MenuTree lb)
        {

           
            List<pageparent> FullMenuTree = new List<pageparent>();
            //PageDataCollection PageData = DataFactory.Instance.GetChildren(new PageReference(ConfigurationManager.AppSettings["RootPage"]));
            PageDataCollection PageData = DataFactory.Instance.GetChildren(lb.Parentreference);


            foreach (var i in PageData)
            {
                pageparent PagePrnt = new pageparent();
                PagePrnt.pagename = i.Name;
                PagePrnt.pageid = i.ContentLink.ID;
                PagePrnt.Link = UrlResolver.Current.GetUrl(i);
                PagePrnt.child = new List<pageparent>();
                PagePrnt.child = loadchild(i.ContentLink.ID);
                if (PagePrnt.Link != null)
                {
                    FullMenuTree.Add(PagePrnt);
                }

            }
            
            return Json(FullMenuTree, JsonRequestBehavior.AllowGet);
            
        }

        /*FRM011 this method gets the child of the selected pages and return the child if the pages has child in it. */
        public List<pageparent> loadchild(int a) {
           
            List<pageparent> Parent = new List<pageparent>();
            

            PageDataCollection PDC = DataFactory.Instance.GetChildren(new PageReference(a));
            if (PDC.Count > 0)
            {                
                foreach (var Child in PDC) {
                    pageparent PagePrnt = new pageparent();
                    PagePrnt.pagename = Child.Name;
                    PagePrnt.pageid = Child.ContentLink.ID;
                    PagePrnt.Link = UrlResolver.Current.GetUrl(Child);
                    PagePrnt.child = loadchild(PagePrnt.pageid);
                    if (PagePrnt.Link != null)
                    {
                        Parent.Add(PagePrnt);
                    }
                }   
                
                }
            
            return Parent;
        }
        
    }
    
    public class pageparent
    {
        public int pageid { get; set; }
        public string pagename { get; set; }

        public string Link { get; set; }

        public List<pageparent> child { get; set; }

      
    }

    //Start : Comments Added for future Reference

//    public class GetLinks
//    {
//       //foreach (var child in children)
////{

////    //PageData p = child;
////    //var a = DataFactory.Instance.GetChildren(new PageReference(p.LinkURL);
////    pageUrl = UrlResolver.Current.GetUrl(child);
////}


//    }




}

// var pageUrl = "";

// PageDataCollection children = EPiServer.DataFactory.Instance.GetChildren(PageReference.RootPage);
////PageDataCollection children1 = EPiServer.DataFactory.Instance.GetChildren(ContentReference.RootPage);
//foreach (var child in children)
//{

//    //PageData p = child;
//    //var a = DataFactory.Instance.GetChildren(new PageReference(p.LinkURL);
//    pageUrl = UrlResolver.Current.GetUrl(child);
//}

//PageDataCollection pages = new PageDataCollection();


//PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();

//PropertyCriteria langCriteria = new PropertyCriteria();
//langCriteria.Name = "PageLanguageBranch";
//langCriteria.Required = true;
//langCriteria.Type = PropertyDataType.String;
//langCriteria.Value = "en";

//criterias.Add(langCriteria);

//pages.Add(DataFactory.Instance.FindPagesWithCriteria(new PageReference(1), criterias));

//var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

//var descendants = contentRepository.GetDescendents(new PageReference(1))
//                                   .Select(contentRepository.Get<IContent>)
//                                   .ToList();

//  PageDataCollection d = DataFactory.Instance.GetChildren(new PageReference(1));



//foreach (var child in descendants)
//{

//  pageUrl = UrlResolver.Current.GetUrl(child);
//}

//End : Comments Added for future Reference