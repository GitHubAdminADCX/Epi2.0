using EPiServer.ClientScript;
using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using WebClient.Business.Entities.DDS;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;


namespace WebClient.Controllers
{
    ///FRM010
    /// Author:Amol Pawar
    ///Purpose of the Class :Generic Functionality(block) to Comment on any type of page with the use of CommentBlock.
    ///Dependent entities : CommentBlock, Pagetype where block can be render,CommentBlockController,Comment.cs,CommentViewModel.cs,DDSComment,CommentService.svc
    ///How to use: 1. Create blockType, controller for block and its view.
    ///            2. Add contentArea in page where we can render this block.
    ///            3. Create DDS table and its class to map the DDS table(Comment.cs)
    ///            4. Create Service to implement the module's logic(CommentService.svc),Check the end points created in web.config, if require do changes in web.config as needed under <system.serviceModel>

    ///Points to take care: 
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>
    public class CommentBlockController : BlockController<CommentBlock>
    {

        // GET: CommentBlock
        public override ActionResult Index(CommentBlock currentBlock)
        {
            string a = "";
            CommentService service = new CommentService();
            byte[] data = service.GetPublicKey();
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                string[] key = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/TextFile1.txt"));
                rijAlg.Key = Convert.FromBase64String("f5Bia7HKcuiGoJEvXDM9ag==");
                rijAlg.IV = Convert.FromBase64String("f5Bia7HKcuiGoJEvXDM9ag=="); 


                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(data))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                //txtKey.Text = srDecrypt.ReadToEnd();
                                a=srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Public key is invalid.')", true);
                }
            }






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
                //commentblockproperties = currentBlock,
                pageId = pageId,
                Comments = list,
                Page = Page,
                pageURl = PageURl.VirtualPath.ToString(),
                publickey = a
            };
            //var model = BlockViewModel.Create(currentBlock);
            //return PartialView();
            return View(model);
        }

    }
}