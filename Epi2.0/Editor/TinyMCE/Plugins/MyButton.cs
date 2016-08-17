using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Editor.TinyMCE;

namespace WebClient.Editor.TinyMCE.Plugins
{
    /// <summary>
    /// FRM006
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Creates a button in tiny mce plugin in Episerver Admin
    /// How to use: Add the control from the custom setting of the XHTMLString property    
    /// Points to take care: will have a editor_plugin js file. 
    /// </summary>
    [TinyMCEPluginButton(
         PlugInName = "MyButton",
         ButtonName = "MyButton",
         GroupName = "misc",
         IconUrl = "/Util/Editor/tinymce/plugins/MyButton/Mybutton.gif")]
    public class MyButton
    {
    }
}