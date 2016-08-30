using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Business.Entities.DDS
{
    [EPiServerDataTable(TableName = "tblBigTableMail")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "Episerver")]
    class DDS_Mail : IDynamicData
    {
        public Identity Id { get; set; }
        public int MailId { get; set; }
        public string SendToMail { get; set; }
       
    }
}
