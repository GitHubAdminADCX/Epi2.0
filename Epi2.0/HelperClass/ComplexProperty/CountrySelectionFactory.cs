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
    public class CountrySelectionFactory : ISelectionFactory
    {
        //FRM023
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var commentStore = DynamicDataStoreFactory.Instance.GetStore(typeof(DDS_Location));
            var allData = commentStore.Items<DDS_Location>();
            var query = (from sendmail in allData
                         select new { CountryCode = sendmail.CountryCode, CountryName = sendmail.CountryName }).AsEnumerable().Distinct();
            var list = query.ToList();
            int i = 0;
            Country[] countries = new Country[list.Count];
            foreach (var places in list)
            {
                countries[i] = new Country() { CountryCode = places.CountryCode, Name = places.CountryName };
                i = i + 1;
            }
            return countries;
        }
    }
}
