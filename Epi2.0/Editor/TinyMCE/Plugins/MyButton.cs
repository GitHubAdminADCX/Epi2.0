using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Editor.TinyMCE;

namespace WebClient.Editor.TinyMCE.Plugins
{
    /// <summary>
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Creates a button in tiny mce plugin in Episerver Admin
    /// How to use: Add the control from the custom setting of the XHTMLString property    
    /// </summary>

    [TinyMCEPluginButton(
         PlugInName = "MyButton",
         ButtonName = "MyButton",
        GroupName = "misc",
        IconUrl = "Editor/tinymce/plugins/MyButton/MyButton.gif")]
    public class MyButton
    {
    }
}