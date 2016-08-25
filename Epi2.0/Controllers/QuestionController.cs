using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using WebClient.Models.Blocks;
using WebClient.Models.ViewModels;

namespace WebClient.Controllers
{
    public class QuestionController : BlockController<QuestionsBlockType>
    {
        public override ActionResult Index(QuestionsBlockType currentBlock)
        {           
            return PartialView(currentBlock);
        }
    }
}
