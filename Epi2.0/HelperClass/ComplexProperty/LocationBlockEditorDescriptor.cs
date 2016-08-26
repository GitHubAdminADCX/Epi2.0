using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models.Blocks;

namespace WebClient.HelperClass.ComplexProperty
{
    [EditorDescriptorRegistration(TargetType = typeof(LocationBlock))]
    class LocationBlockEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);
            metadata.Properties.Cast<ExtendedMetadata>().First().GroupSettings.ClientLayoutClass = "myproject.LocationBlockEditor.LocationBlockContainer";
        }
    }
}
