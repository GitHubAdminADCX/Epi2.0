using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Business.Entities.DDS
{
    [EPiServerDataTable(TableName = "tblBigTableLocation")]
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "Epi")]
    class DDS_Location
    {
        public Identity Id { get; set; }
      
        public string RegionName { get; set; }

        public string RegionCode { get; set; }

        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
