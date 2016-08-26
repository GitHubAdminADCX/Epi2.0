using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.HelperClass.ComplexProperty
{
    public class Country : ISelectItem
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }

        public string Text
        {
            get
            {
                return Name;
            }
        }

        public object Value
        {
            get
            {
                return CountryCode;
            }
        }
    }
}
