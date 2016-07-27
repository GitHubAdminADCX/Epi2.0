using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Editor.TinyMCE;

namespace WebClient.Editor.TinyMCE.Plugins
{
    /// <summary>
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Creates a non visual plugin in tiny mce plugin in Episerver Admin to paste text unformatted.
    /// How to use: Add the control from the custom setting of the XHTMLString property    
    /// Points to take care: will have a editor_plugin js file. 
    /// </summary>
    [TinyMCEPluginNonVisual(
          AlwaysEnabled = true,
          PlugInName = "PasteUnformattedPlugin",
          DisplayName = "Custom editor paste unformatted",
          Description = "Loads custom editor paste unformatted option",         
          DefaultEnabled = true,
          EditorInitConfigurationOptions = @"{
            paste_text_sticky: true,
            paste_text_sticky_default: true,
			theme_advanced_disable: 'code',
            forced_root_block : 'p',
            force_br_newlines : true,
            force_p_newlines : true,
            convert_newlines_to_brs : false
          }"
          )]
    public class PasteUnformattedPlugin
    {
    }
}