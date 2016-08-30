using EPiServer.Data.Dynamic;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Business.Entities.DDS;

namespace WebClient.HelperClass.ComplexProperty
{
    //FRM023
    class RegionSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Location));
            var allData = commentStore.Items<DDS_Location>();
            var query = from sendmail in allData
                        select sendmail;
            var list = query.ToList<DDS_Location>();

            int i = 0;
            Region[] reg = new Region[list.Count];
            foreach (var places in list)
            {
                reg[i] = new Region() { CountryCode = places.CountryCode, Name = places.RegionName, RegionCode = places.RegionCode };
                i = i + 1;
            }
            return reg;
        }
    }
}
