using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.HelperClass.ComplexProperty
{
    class RegionSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new Region[]
            {
            new Region() { CountryCode = "US", RegionCode = "NY", Name = "New York" },
            new Region() { CountryCode = "US", RegionCode = "CA", Name = "California" },

            new Region() { CountryCode = "SE", RegionCode = "AB", Name = "Stockholm" },
            new Region() { CountryCode = "SE", RegionCode = "O", Name = "Västra Götaland" }
            };
        }
    }
}
