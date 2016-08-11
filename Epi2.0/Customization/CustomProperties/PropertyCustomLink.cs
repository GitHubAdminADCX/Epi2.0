using EPiServer.Core;
using EPiServer.PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebClient.Models.ViewModels;

namespace WebClient.Customization.CustomProperties
{
    [PropertyDefinitionTypePlugIn(Description = "A property for list of links.", DisplayName = "Links property")]
    public class PropertyCustomLink : PropertyLongString
    {
        public override Type PropertyValueType
        {
            get { return typeof(IEnumerable<LinkDetails>); }
        }

        public override object Value
        {
            get
            {
                var value = base.Value as string;
                if (value == null)
                {
                    return null;
                }
                var serializer = new JavaScriptSerializer();
                return serializer.Deserialize(value, typeof(IEnumerable<LinkDetails>));
            }
            set
            {
                if (value is IEnumerable<LinkDetails>)
                {
                    var serializer = new JavaScriptSerializer();
                    base.Value = serializer.Serialize(value);
                }
                else
                {
                    base.Value = value;
                }
            }
        }

        public override object SaveData(PropertyDataCollection properties)
        {
            return LongString;
        }
    }
}