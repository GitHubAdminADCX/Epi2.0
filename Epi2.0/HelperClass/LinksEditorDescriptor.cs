using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.Models.ViewModels;

namespace WebClient.HelperClass
{
    [EditorDescriptorRegistration(TargetType = typeof(IEnumerable<LinkDetails>), UIHint = "LinksProperty")]
    public class LinksEditorDescriptor : EditorDescriptor
    {
        public LinksEditorDescriptor()
        {
            ClientEditingClass = "custom.LinksCustomProperty.LinksProperty";
        }
    }

}