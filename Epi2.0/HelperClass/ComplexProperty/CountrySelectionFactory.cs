using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.HelperClass.ComplexProperty
{
    public class CountrySelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new Country[]
            {
            new Country() { CountryCode = "US", Name = "United States" },
            new Country() { CountryCode = "SE", Name = "Sweden" }
            };
        }
    }
}
