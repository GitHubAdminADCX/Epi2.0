using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;

namespace WebClient.HelperClass
{
    ///Author:Amol Pawar
    ///Purpose of the Class :A simple horizontal line separating two properties in edit mode of a page
    ///Dependent entities : Helper Class  DividerProperty, PropertyEditorDescriptor. Helper JS,CSS - Folder Name ClientResources. Module.Config . PropertiesDividerController and its view(Optional, Depends on ur requirements)
    ///How to use: 1. Create One PageType As below including two properties which wants to seperate.
    ///            2. Set BackingType as DividerProperty (...[BackingType(typeof(DividerProperty))]....) .
    ///            3. Add helper Class DividerProperty , PropertyEditorDescriptor.
    ///            4. Add JS And CSS as in path ClientResources(See the ClientResources Folder.
    ///            5. Addd module.config and edit as per project solution.
    ///Points to take care: The specification in module.config <dojoModules>
    ///                                                        <add name = "custom" path="Scripts" />
    ///                                                        </dojoModules>
    ///Highlight Risk : <Highlight risk if any involved>
    ///Comments: <Any comment meant for the developer>



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