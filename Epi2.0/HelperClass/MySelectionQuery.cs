using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models.Pages;
using System.Web;

namespace WebClient.HelperClass
{
    //FRM019:custom property editor 
    [ServiceConfiguration(typeof(ISelectionQuery))]
    public class MySelectionQuery : ISelectionQuery
    {
      private static HttpCookie myCookie = new HttpCookie("UserSettings");
        SelectItem[] _items=new SelectItem[Convert.ToInt16(myCookie.Value)];
  
        public MySelectionQuery()
        {
            var a = DataFactory.Instance.Get<StandardPageType>(ContentReference.StartPage);
            string s = a.Autocompletekeywords;
            // Split string on spaces.
            // ... This will separate all the words.
             string[] words = s.Split(',');
            myCookie.Value = words.Length.ToString();

            try
            {
                int i = 0;
                foreach (var word in words)
                {
                    _items[i] = new SelectItem() { Text = word,Value=i };
                    i = i + 1;
                }

            }

            catch (Exception ex)
            { }
        }

       
        //Will be called when the editor types something in the selection editor. 

        public IEnumerable<ISelectItem> GetItems(string query)
        {
            return _items.Where(i => i.Text.StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }
        //Will be called when initializing an editor with an existing value to get the corresponding text representation.       
        public ISelectItem GetItemByValue(string value)
        {
            return _items.FirstOrDefault(i => i.Value.Equals(value));
        }
    }

}
