using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;

namespace Epi2._0.HelperClass
{
    [EditorDescriptorRegistration(TargetType = typeof(DividerProperty), UIHint = "Divider")]
    public class DividerEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(EPiServer.Shell.ObjectEditing.ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "custom.editors.divider";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}