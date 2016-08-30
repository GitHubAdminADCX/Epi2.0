using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.HelperClass
{
    //ID :FRM028
    //Developer : Kunal
    //Steps : 1. Define Dojo property in modules config. Here dojo module
    //           section points to the folder that will contain our dojo stuff.
    //           these folders will live within the ClientResources folder. You can’t change this 
    //        2. within your scripts folder, you need to create your dojo file .here we create DojoProperty.js
    //        3. We can also create a dojo view in the templates floder or else we can assingn HTML directly to "templateString" proeperty in our DojoProperty.js
    //        4. Then we need to create and EditorDescriptor as shown below. The string assigned to ClientEditingClass below is the same as that given in "declare"  inside DojoProperty.js
    //        5. Last thing needed is declaring attribute  [UIHint("CustomProperty")] on our property in the model folder.
    [EditorDescriptorRegistration(
       TargetType = typeof(String),
       UIHint = "CustomProperty")]
    class DojoPropertyDescriptor : EditorDescriptor
    {
        public DojoPropertyDescriptor()
        {
            ClientEditingClass = "jondjones.CustomProperty.DojoProperty";
        }
    }

}

