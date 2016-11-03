using EPiServer.Data.Dynamic;
using EPiServer.Licensing.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Services;
using WebClient.Business.Entities.DDS;

namespace WebClient
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
    [ServiceContract(Namespace = "CommentService")]
    [System.Web.Script.Services.ScriptService]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommentService 
    {

       
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public string DoWork(string strpppp)
        {
            // Add your operation implementation here
            return "Heloo";
        }

      

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        public Comment Addcomment(int pageId, string commentText, string urlstring, string commentId)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            string CommentGuid = Guid.NewGuid().ToString();
            var comment = new Comment()
            {
                CommentId = CommentGuid,
                CommentText = commentText,
                Date = DateTime.Now,
                UserName = "AP",
                PageId = pageId,
                IsCommentDeleted = false,
                ParentCommentId = commentId == "" ? "" : commentId

            };

            commentStore.Save(comment);

            { }

            var er = commentStore.Items<Comment>();

            var query = from comments in er
                        where comments.CommentId == CommentGuid                        
                        select comments;

            var list = query.ToList<Comment>();

            return list[0];
        }


       
        [OperationContract]
        [WebInvoke(Method = "GET")]
        public List<Comment> GetAllChildComments(string ParentCommentId)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(Comment));
            var er = commentStore.Items<Comment>();
            var query = from comments in er
                        where comments.ParentCommentId == ParentCommentId
                        orderby comments.Date ascending
                        select comments;
            var list = query.ToList<Comment>();

            return list;
        }

        [WebMethod(CacheDuration = 24 * 60 * 60)]
        public byte[] GetPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //Add Key Pair (Public + Private Key) to Cache to be used by ValidateUser
            HttpRuntime.Cache["KeyPair"] = rsa.ToXmlString(true);
           
            RSAParameters param = rsa.ExportParameters(false);
           

            string keyToSend = ToHexString(param.Exponent) + "," +
                 ToHexString(param.Modulus);

            // Encrypting public key to block Man-in-the-Middle attack
            byte[] encrypted;
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                //string[] key = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/TextFile1.txt"));
                //myRijndael.Key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw ==");
                myRijndael.Key = Convert.FromBase64String("f5Bia7HKcuiGoJEvXDM9ag==");
                myRijndael.IV = Convert.FromBase64String("f5Bia7HKcuiGoJEvXDM9ag==");

                ICryptoTransform encryptor = myRijndael.CreateEncryptor();
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            swEncrypt.Write(keyToSend);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }


      public static string ToHexString(byte[] byteValue)
        {
            char[] lookup = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int i = 0, p = 0, l = byteValue.Length;
            char[] c = new char[l * 2];
            while (i < l)
            {
                byte d = byteValue[i++];
                c[p++] = lookup[d / 0x10];
                c[p++] = lookup[d % 0x10];
            }
            return new string(c, 0, c.Length);
        }
        public static byte[] ToHexByte(string str)
        {
            byte[] b = new byte[str.Length / 2];
            for (int y = 0, x = 0; x < str.Length; ++y, x++)
            {
                byte c1 = (byte)str[x];
                if (c1 > 0x60) c1 -= 0x57;
                else if (c1 > 0x40) c1 -= 0x37;
                else c1 -= 0x30;
                byte c2 = (byte)str[++x];
                if (c2 > 0x60) c2 -= 0x57;
                else if (c2 > 0x40) c2 -= 0x37;
                else c2 -= 0x30;
                b[y] = (byte)((c1 << 4) + c2);
            }
            return b;
        }



        [WebGet]
        [WebMethod(EnableSession = true)]
        public string getdecrypted(string name) {
            string domainKey = (string)HttpRuntime.Cache["KeyPair"];

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(domainKey);
            string username = Encoding.UTF8.GetString(rsa.Decrypt(ToHexByte(name), false));
            //string password = Encoding.UTF8.GetString(rsa.Decrypt(ToHexByte(encPassword), false));
            return username;
        }


    }
    }
